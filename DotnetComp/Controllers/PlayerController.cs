using DotnetComp.Errors;
using DotnetComp.Models.Domain;
using DotnetComp.Models.Dto;
using DotnetComp.Models.Entities;
using DotnetComp.Models.Requests;
using DotnetComp.Results;
using DotnetComp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetComp.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
        : ControllerBase
    {
        private readonly ILogger<PlayerController> logger = logger;
        private readonly IPlayerService playerService = playerService;

        [HttpGet()]
        public async Task<ActionResult<GetPlayerDTO>> GetPlayer([FromQuery] string playerName)
        {
            if (playerName.Length < 3 || playerName.Length > 100 || playerName == null)
            {
                return BadRequest(
                    "The length of the player's name cannot be less than 3 and greater than 100"
                );
            }

            var result = await playerService.GetPlayer(playerName);
            logger.LogDebug("Retrieving player {playerName}", playerName);
            return result.Match(
                onSuccess: () =>
                {
                    var player = result.Value;
                    var dto = new GetPlayerDTO
                    {
                        Name = player.PlayerName,
                        ExperienceGainedLast24H = player.ExperienceGainedLast24H,
                        ExperienceGainedLastWeek = player.ExperienceGainedLastWeek,
                        TotalExperience = player.TotalExperience,
                    };
                    return Ok(dto);
                },
                onFailure: (error) =>
                {
                    return error.ErrorType switch
                    {
                        ErrorType.NotFound => NotFound("Player not found"),
                        _ => StatusCode(500, "An unexpected error occurred"),
                    };
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(
            [FromBody] CreatePlayerRequest createPlayerRequest
        )
        {
            var result = await playerService.CreatePlayer(createPlayerRequest.PlayerName);
            return result.Match(
                onSuccess: () =>
                {
                    return Ok(result);
                },
                onFailure: (error) =>
                {
                    return error.ErrorType switch
                    {
                        _ => StatusCode(500, "An unexpected error occured"),
                    };
                }
            );
        }
    }
}
