using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;

using Skymly.JyGameStudio.Api.Data;
using Skymly.JyGameTools.Models;
using Tools;
namespace Skymly.JyGameStudio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AoyiController : ControllerBase
    {
        private readonly ScriptsContext _context;
        private ILogger<AoyiController> _logger;

        public AoyiController(ScriptsContext context, ILogger<AoyiController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// 获取全部奥义
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aoyi>>> GetAoyi()
        {
            return await _context.Aoyis.Include(v => v.AoyiConditions).ToListAsync();
        }

        /// <summary>
        /// 获取全部奥义,XML结构
        /// </summary>
        /// <returns></returns>
        [HttpGet("xml")]
        public async Task<ActionResult<string>> GetAoyiRoot()
        {
            var root = new AoyiRoot
            {
                Aoyis = await _context.Aoyis.Include(v => v.AoyiConditions).ToListAsync()
            };
            var xml = XmlSerializeTool.SerializeToString(root);
            return xml;
        }

        /// <summary>
        /// 根据ID获取奥义
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Aoyi>> GetAoyi(Guid id)
        {
            var aoyi = await _context.Aoyis.Include(v => v.AoyiConditions).FirstOrDefaultAsync(v => v.Id == id);

            if (aoyi == null)
            {
                return NotFound();
            }

            return aoyi;
        }

        // PUT: api/Aoyi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAoyi(Guid id, Aoyi aoyi)
        {
            if (id != aoyi.Id)
            {
                return BadRequest();
            }

            _context.Entry(aoyi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AoyiExists(id))
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
        public async Task<ActionResult<Aoyi>> PostAoyi(Aoyi aoyi)
        {
            _context.Aoyis.Add(aoyi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAoyi", new { id = aoyi.Id }, aoyi);
        }

        // DELETE: api/Aoyi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAoyi(Guid id)
        {
            var aoyi = await _context.Aoyis.FindAsync(id);
            if (aoyi == null)
            {
                return NotFound();
            }

            _context.Aoyis.Remove(aoyi);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AoyiExists(Guid id)
        {
            return _context.Aoyis.Any(e => e.Id == id);
        }

        [HttpPost("ResetData")]
        public async ValueTask<IEnumerable<Aoyi>> ResetData()
        {
            try
            {
                var old = await _context.Aoyis.Include(v => v.AoyiConditions).ToListAsync();
                _context.RemoveRange(old);
                await _context.SaveChangesAsync();
                var xml = System.IO.File.ReadAllText("Mod/Scripts/aoyis.xml");
                _logger.LogInformation(xml);
                var aoyis = XmlSerializeTool.DeserializeFromString<AoyiRoot>(xml).Aoyis;
                await _context.AddRangeAsync(aoyis);
                await _context.SaveChangesAsync();
                return aoyis;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
