using Microsoft.AspNetCore.Mvc;
using DotnetComp.Models.Dto;
using DotnetComp.Results;
using DotnetComp.Services;
using DotnetComp.Errors;

namespace DotnetComp.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController(ILogger<PlayerController> logger, IPlayerService playerService) : ControllerBase
    {
        private readonly ILogger<PlayerController> logger = logger;
        private readonly IPlayerService playerService = playerService;

        [HttpGet()]
        public async Task<ActionResult<GetPlayerDTO>> GetPlayer()
        {
            var result = await playerService.GetPlayer(123);
            return result.Match(
                onSuccess: () =>
                {
                    var dto = new GetPlayerDTO
                    {
                        Name = result.Value.PlayerName
                    };
                    return Ok(dto);
                },
                onFailure: (error) =>
                {
                    return error.ErrorType switch
                    {
                        ErrorType.NotFound => NotFound("Player not found"),
                        _ => StatusCode(500, "An unexpected error occurred")
                    };
                }
            );
        }
    }
}