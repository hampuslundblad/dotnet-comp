using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using dotnet_comp.Services;
using dotnet_comp.Models.Dto;

namespace dotnet_comp.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController(ILogger<PlayerController> logger, PlayerService playerService) : ControllerBase
    {
        private readonly ILogger<PlayerController> logger = logger;
        private readonly PlayerService playerService = playerService;

        [HttpGet("hiscore")]
        public async Task<ActionResult<PlayerHiscoreDTO>> Get([FromQuery] string name)
        {
            logger.LogInformation("Getting hiscore data for {name}", name);
            var response = await playerService.GetPlayerHiscoreDataAsync(name);
            if (response.IsSucess)
            {
                var result = PlayerHiscoreDTO.FromDomain(response.Value);
                return Ok(result);
            }

            logger.LogError("Error retrieving hiscore data");
            return StatusCode(500, "Error retrieving hiscore data");
        }

    }
}