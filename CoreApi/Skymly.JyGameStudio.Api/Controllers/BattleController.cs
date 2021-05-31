using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Skymly.JyGameStudio.Data;
using Skymly.JyGameStudio.Models;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

using Tools;

namespace Skymly.JyGameStudio.Api.Controllers
{
    /// <summary>
    /// 战斗
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly ScriptsContext _context;
        private ILogger<BattleController> _logger;
        readonly IWebHostEnvironment _env;
        public BattleController(ScriptsContext context, ILogger<BattleController> logger, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// 获取全部战斗
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battle>>> Get()
        {
            return await _context.Battle.Include(v => v.BattleRoles).ToListAsync();
        }

        /// <summary>
        /// 获取全部战斗,XML结构
        /// </summary>
        /// <returns></returns>
        [HttpGet("xml")]
        public async Task<ActionResult<string>> Xml()
        {
            var root = new BattleRoot
            {
                Battles = await _context.Battle.Include(v => v.BattleRoles).ToListAsync()
            };
            var xml = XmlSerializeTool.SerializeToString(root);
            return xml;
        }

        /// <summary>
        /// 根据ID获取战斗
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Battle>> GetBattle(Guid id)
        {
            var battles = await _context.Battle.Include(v => v.BattleRoles).FirstOrDefaultAsync(v => v.Id == id);

            if (battles == null)
            {
                return NotFound();
            }

            return battles;
        }

        // PUT: api/Aoyi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattle(Guid id, Battle battle)
        {
            if (id != battle.Id)
            {
                return BadRequest();
            }

            _context.Entry(battle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Aoyi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Battle>> PostBattle(Battle battle)
        {
            _context.Battle.Add(battle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBattle), new { id = battle.Id }, battle);
        }

        // DELETE: api/Aoyi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAoyi(Guid id)
        {
            var data = await _context.Battle.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Battle.Remove(data);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool BattleExists(Guid id)
        {
            return _context.Battle.Any(e => e.Id == id);
        }

        /// <summary>
        /// 重置数据库
        /// </summary>
        /// <returns></returns>
        [HttpPost("ResetData")]
        //public async ValueTask<ActionResult<IEnumerable<Battle>>> ResetData()
        public async Task<ActionResult<IEnumerable>> ResetData()
        {
            try
            {
                var old = await _context.Battle.Include(v => v.BattleRoles).ToListAsync();
                _context.RemoveRange(old);
                await _context.SaveChangesAsync();
                var xml = System.IO.File.ReadAllText("Mod/Scripts/battles.xml");
                var battles = XmlSerializeTool.DeserializeFromString<BattleRoot>(xml).Battles;
                await _context.AddRangeAsync(battles);
                await _context.SaveChangesAsync();
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
                var json = JsonSerializer.Serialize(battles, options);
                _logger.LogDebug(json);
                if (_env.IsDevelopment())
                {
                    return battles.Select(v => v.Key).ToList();
                }
                else
                {
                    return battles;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

    }
}
