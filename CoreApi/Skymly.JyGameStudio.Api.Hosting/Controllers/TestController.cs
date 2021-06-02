using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.Api.Hosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return typeof(IOpenApiExtension).Assembly.GetTypes().Where(v=>v.IsAssignableFrom(typeof(IOpenApiExtension))).Select(v=>v.FullName);
        }
        [HttpGet("GetTypes")]
        public IEnumerable<string> Get1()
        {
            return typeof(IOpenApiExtension).Assembly.GetTypes().Where(v => typeof(IOpenApiExtension).IsAssignableFrom(v)).Select(v => v.FullName); ;
        }

    }
}
