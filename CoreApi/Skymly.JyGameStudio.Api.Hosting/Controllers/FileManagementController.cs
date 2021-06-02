using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skymly.JyGameStudio.Api.Hosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagementController : ControllerBase
    {
        private ILogger<FileManagementController> _logger;
        IWebHostEnvironment _env;
        public FileManagementController(ILogger<FileManagementController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        /// <summary>
        /// 下载XML脚本
        /// </summary>
        /// <param name="name">脚本名称,包含扩展名,example:aoyis.xml</param>
        /// <returns></returns>
        [HttpGet("Scripts/{name}")]
        public IActionResult Scripts(string name)
        {
            return GetFile(name);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Icons/{name}")]
        public IActionResult Icons(string name)
        {
            return GetFile(name);
        }

        /// <summary>
        /// 获取地图图片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Maps/{name}")]
        public IActionResult Maps(string name)
        {
            return GetFile(name);
        }

        /// <summary>
        /// 获取音乐、音效
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Audios/{name}")]
        public IActionResult Audios(string name)
        {
            return GetFile(name);
        }

        /// <summary>
        /// 获取物品图片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Items/{name}")]
        public IActionResult GetItem(string name)
        {
            return GetFile(name);
        }

        /// <summary>
        /// 获取头像图片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Heads/{name}")]
        public IActionResult GetHead(string name)
        {
            return GetFile(name);
        }

        /// <summary>
        /// 根据文件名称和文件夹名称,返回第一个文件,
        /// </summary>
        /// <param name="fileName">文件名称 example:zhua.jpg</param>
        /// <param name="dirName">文件夹名称 如果为空，则在整个MOD中搜索</param>
        /// <returns></returns>
        [HttpGet("GetFile/{fileName}")]
        public IActionResult GetFile(string fileName, [CallerMemberName] string dirName = "")
        {
            string fullName = string.Empty;
            string entryDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            if (string.IsNullOrEmpty(dirName))
            {
                var mod = new DirectoryInfo(Path.Combine(entryDir, "Mod"));
                var file = mod.GetFiles(string.Empty, SearchOption.AllDirectories).FirstOrDefault(v => v.Name == fileName);
                fullName = file?.FullName ?? fullName;
            }
            else
            {
                fullName = Path.Combine(entryDir, "Mod", dirName, fileName);
            }
            if (System.IO.File.Exists(fullName))
            {
                var extension = Path.GetExtension(fullName);
                var contentType = Helper.GetContentType(extension);
                _logger.LogInformation($"ContentType = {contentType},FileName = {fileName}");
                return PhysicalFile(fullName, contentType, fileName);
            }
            else
            {
                return NotFound($"{fullName} Not Exists");
            }
        }

        [HttpGet]
        /// <summary>
        /// Files
        /// </summary>
        /// <returns></returns>
        public RedirectResult Index()
        {
            return Redirect("http://localhost:5001/Mod");
        }

    }
}
