using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Serilog.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.Api.Hosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerilogTestController : ControllerBase
    {
        ILogger<SerilogTestController> _logger;
        public SerilogTestController(ILogger<SerilogTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(nameof(LogDebug))]
        public void LogDebug()
        {
            _logger.LogDebug($"{nameof(LogDebug)} 被调用了");
        }

        [HttpGet(nameof(LogInformation))]
        public void LogInformation()
        {
            _logger.LogInformation($"{nameof(LogInformation)} 被调用了");
        }
        [HttpGet(nameof(LogError))]
        public void LogError()
        {
            _logger.LogError($"{nameof(LogError)} 被调用了");
        }
        [HttpGet(nameof(LogTrace))]
        public void LogTrace()
        {
            _logger.LogTrace($"{nameof(LogTrace)} 被调用了");
        }
        [HttpGet(nameof(LogCritical))]
        public void LogCritical()
        {
            _logger.LogCritical($"{nameof(LogCritical)} 被调用了");
        }
        [HttpGet(nameof(LogWarning))]
        public void LogWarning()
        {
            _logger.LogWarning($"{nameof(LogWarning)} 被调用了");
        }

    }
}
