using Microsoft.AspNetCore.Mvc;
using DotnetComp.Services;
using DotnetComp.Models.Dto;
using DotnetComp.Errors;
using DotnetComp.Results;

namespace DotnetComp.Controllers
{
    [ApiController]
    [Route("hiscore")]
    public class HiscoreController(ILogger<HiscoreController> logger, IHiscoreService hiscoreService) : ControllerBase
    {
        private readonly ILogger<HiscoreController> logger = logger;
        private readonly IHiscoreService hiscoreService = hiscoreService;

        [HttpGet("hiscore")]
        public async Task<ActionResult<PlayerHiscoreDTO>> Get([FromQuery] string name)
        {
            if (name.Length < 3 || name.Length > 100)
            {
                return BadRequest("Player name is either too long or too short");
            }

            logger.LogInformation("Getting hiscore data for {name}", name);
            var response = await hiscoreService.GetPlayerHiscoreDataAsync(name);

            return response.Match(
                 value =>
                 {
                     var result = PlayerHiscoreDTO.FromDomain(value);
                     return Ok(result);
                 },
                 error => StatusCode(500, "test")
             );
            //     return response.Match(
            //         onSuccess: () =>
            //         {
            //             var result = PlayerHiscoreDTO.FromDomain(response.Value);
            //             return Ok(result);
            //         },
            //         onFailure: error =>
            //         {
            //             return error switch
            //             {
            //                 ErrorType.NotFound => StatusCode(404, error.Description),
            //                 ErrorType.Failure => StatusCode(500, error.Description),
            //                 _ => StatusCode(500, "Something unexpected went wrong")
            //             };
            //         }
            //     );
        }
    }
}