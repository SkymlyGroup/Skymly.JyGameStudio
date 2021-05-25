using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skymly.JyGameStudio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagementController : ControllerBase
    {
        private ILogger<FileManagementController> _logger;

        public FileManagementController(ILogger<FileManagementController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 下载XML脚本
        /// </summary>
        /// <param name="name">脚本名称,包含扩展名,example:aoyis.xml</param>
        /// <returns></returns>
        [HttpGet("Scripts/{name}")]
        public IActionResult GetXmlScript(string name)
        {
            var file = Path.Combine(Environment.CurrentDirectory, "Mod/Scripts", name);
            _logger.LogInformation(file);
            return System.IO.File.Exists(file) ? PhysicalFile(file, "text/xml", name) : NotFound($"{file} Not Exists");
        }

        /// <summary>
        /// 下载文件,以Mod文件夹为根目录
        /// </summary>
        /// <param name="path">对于Mod文件夹的相对路径路径，example1:Icons/icon_neigong_003.jpg  example2:Audios/battle2.ogg </param>
        /// <returns></returns>
        [HttpGet("ModFile")]
        public IActionResult GetFile([Required] string path)
        {
            _logger.LogInformation($"Test asdasdasdads");
            _logger.LogInformation(path);
            var fullName = Path.Combine(Environment.CurrentDirectory, "Mod", path);
            _logger.LogInformation(fullName);
            if (System.IO.File.Exists(fullName))
            {
                var extension = Path.GetExtension(fullName);
                var contentType = Helper.GetContentType(extension);
                _logger.LogWarning($"contentType:{contentType}");
                var fileName = System.IO.Path.GetFileName(fullName);
                return PhysicalFile(fullName, contentType, fileName);
            }
            else
            {
                return NotFound($"{fullName} Not Exists");
            }
        }

        [HttpGet("Icons")]
        public IActionResult GetIcon([Required] string name)
        {
            var fullName = Path.Combine(Environment.CurrentDirectory, "Mod/Icons", name);
            _logger.LogInformation(fullName);
            if (System.IO.File.Exists(fullName))
            {
                var extension = Path.GetExtension(fullName);
                var contentType = Helper.GetContentType(extension);
                _logger.LogWarning($"contentType:{contentType}");
                var fileName = System.IO.Path.GetFileName(fullName);
                return PhysicalFile(fullName, contentType, fileName);
            }
            else
            {
                return NotFound($"{fullName} Not Exists");
            }
        }

        [HttpGet("Maps")]
        public IActionResult GetMap([Required] string name)
        {
            var fullName = Path.Combine(Environment.CurrentDirectory, "Mod/Maps", name);
            _logger.LogInformation(fullName);
            if (System.IO.File.Exists(fullName))
            {
                var extension = Path.GetExtension(fullName);
                var contentType = Helper.GetContentType(extension);
                _logger.LogWarning($"contentType:{contentType}");
                var fileName = System.IO.Path.GetFileName(fullName);
                return PhysicalFile(fullName, contentType, fileName);
            }
            else
            {
                return NotFound($"{fullName} Not Exists");
            }
        }

        [HttpGet("Audios")]
        public IActionResult GetAudio([Required] string name)
        {
            var fullName = Path.Combine(Environment.CurrentDirectory, "Mod/Audios", name);
            _logger.LogInformation(fullName);
            if (System.IO.File.Exists(fullName))
            {
                var extension = Path.GetExtension(fullName);
                var contentType = Helper.GetContentType(extension);
                _logger.LogWarning($"contentType:{contentType}");
                var fileName = System.IO.Path.GetFileName(fullName);
                return PhysicalFile(fullName, contentType, fileName);
            }
            else
            {
                return NotFound($"{fullName} Not Exists");
            }
        }

        [HttpGet("Items")]
        public IActionResult GetItem([Required] string name)
        {
            var fullName = Path.Combine(Environment.CurrentDirectory, "Mod/Items", name);
            _logger.LogInformation(fullName);
            if (System.IO.File.Exists(fullName))
            {
                var extension = Path.GetExtension(fullName);
                var contentType = Helper.GetContentType(extension);
                _logger.LogWarning($"contentType:{contentType}");
                var fileName = System.IO.Path.GetFileName(fullName);
                return PhysicalFile(fullName, contentType, fileName);
            }
            else
            {
                return NotFound($"{fullName} Not Exists");
            }
        }

        [HttpGet("Heads")]
        public IActionResult GetHead([Required] string name)
        {
            var fullName = Path.Combine(Environment.CurrentDirectory, "Mod/Heads", name);
            _logger.LogInformation(fullName);
            if (System.IO.File.Exists(fullName))
            {
                var extension = Path.GetExtension(fullName);
                var contentType = Helper.GetContentType(extension);
                _logger.LogWarning($"contentType:{contentType}");
                var fileName = System.IO.Path.GetFileName(fullName);
                return PhysicalFile(fullName, contentType, fileName);
            }
            else
            {
                return NotFound($"{fullName} Not Exists");
            }
        }

    }
}
