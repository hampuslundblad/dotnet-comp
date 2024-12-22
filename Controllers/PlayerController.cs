using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_comp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_comp.Controllers
{
    [ApiController]
    [Route("osrs")]
    public class OsrsController : ControllerBase
    {
        private readonly ILogger<OsrsController> _logger;
        private readonly OsrsService _osrsService;


        public OsrsController(ILogger<OsrsController> logger, OsrsService osrsService)
        {
            _logger = logger;
            _osrsService = osrsService;

        }

        [HttpGet("hiscore")]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            _logger.LogInformation("Getting hiscore data for {name}", name);
            var data = await _osrsService.GetPlayerHiscoreDataAsync(name);
            if (data != null)
            {
                return Ok(data);
            }
            return StatusCode(500, "Error retrieving hiscore data");
        }

    }
}