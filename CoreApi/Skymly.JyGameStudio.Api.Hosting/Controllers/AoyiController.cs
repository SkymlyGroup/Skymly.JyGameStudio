using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;

using Newtonsoft.Json;

using Skymly.JyGameStudio.Data;
using Skymly.JyGameStudio.Models;

using Tools;
namespace Skymly.JyGameStudio.Api.Hosting.Controllers
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
            return await _context.Aoyi.Include(v => v.AoyiConditions).ToListAsync();
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
                Aoyis = await _context.Aoyi.Include(v => v.AoyiConditions).ToListAsync()
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
            var aoyi = await _context.Aoyi.Include(v => v.AoyiConditions).FirstOrDefaultAsync(v => v.Id == id);
            return aoyi is null ? NotFound() : aoyi;
        }

        /// <summary>
        /// 根据Id,修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="aoyi"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="aoyi"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Aoyi>> PostAoyi(Aoyi aoyi)
        {
            _context.Aoyi.Add(aoyi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAoyi), new { id = aoyi.Id }, aoyi);
        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAoyi(Guid id)
        {
            var aoyi = await _context.Aoyi.FindAsync(id);
            if (aoyi == null)
            {
                return NotFound();
            }

            _context.Aoyi.Remove(aoyi);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AoyiExists(Guid id)
        {
            return _context.Aoyi.Any(e => e.Id == id);
        }

        /// <summary>
        /// 重置数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("ResetData")]
        public async ValueTask<IActionResult> ResetData()
        {
            try
            {
                var old = await _context.Aoyi.Include(v => v.AoyiConditions).ToListAsync();
                _context.RemoveRange(old);
                await _context.SaveChangesAsync();
                var xml = System.IO.File.ReadAllText("Mod/Scripts/aoyis.xml");
                var aoyis = XmlSerializeTool.DeserializeFromString<AoyiRoot>(xml).Aoyis;
                await _context.AddRangeAsync(aoyis);
                await _context.SaveChangesAsync();
                var result = new
                {
                    Message = "重置数据成功",
                    Success = true,
                    Aoyi = await _context.Aoyi.CountAsync(),
                    AoyiCondition = await _context.AoyiCondition.CountAsync()
                };
                _logger.LogInformation(JsonConvert.SerializeObject(result, Formatting.Indented));
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new
                {
                    Message = "重置数据失败",
                    Success = false,
                    Exception = ex,
                };
                _logger.LogError(ex, ex.Message);
                return BadRequest(result);
            }
        }

    }
}
