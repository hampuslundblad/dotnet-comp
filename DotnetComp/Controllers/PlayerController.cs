using Microsoft.AspNetCore.Mvc;
using DotnetComp.Services;
using DotnetComp.Models.Dto;

namespace DotnetComp.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController(ILogger<PlayerController> logger, IPlayerService playerService) : ControllerBase
    {
        private readonly ILogger<PlayerController> logger = logger;
        private readonly IPlayerService playerService = playerService;

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