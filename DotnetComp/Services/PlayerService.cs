using System.Linq;
using DotnetComp.Errors;
using DotnetComp.Models.Domain;
using DotnetComp.Repositories;
using DotnetComp.Results;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DotnetComp.Services
{
    public interface IPlayerService
    {
        Task<Result<Player>> GetPlayer(string playerName);
        Task<BaseResult> CreatePlayer(string playerName);
    }

    public class PlayerService(ILogger<PlayerService> logger, IPlayerRepository playerRepository)
        : IPlayerService
    {
        private readonly IPlayerRepository playerRepository = playerRepository;
        private readonly ILogger<PlayerService> logger = logger;


        public async Task<Result<Player>> GetPlayer(string playerName)
        {
            try
            {
                var player = await playerRepository.GetByPlayerName(playerName);
                if (player == null)
                {
                    logger.LogError("Unable to find player with name {playerName}", playerName);
                    return Result<Player>.Failure(PlayerServiceErrror.NotFound());
                }
                else
                {
                    return Result<Player>.Success(Player.ToDomain(player));
                }
            }
            catch (Exception e)
            {
                logger.LogError(
                    e,
                    "Unexpected error occurred while retrieving player with name {playerName}",
                    playerName
                );
                return Result<Player>.Failure(PlayerServiceErrror.ServiceError());
            }
        }

        public async Task<BaseResult> CreatePlayer(string playerName)
        {
            try
            {
                var player = await playerRepository.Create(playerName);
                return BaseResult.Success();
            }
            catch (Exception e)
            {
                logger.LogError("{Message}", e.Message);
                return BaseResult.Failure(PlayerServiceErrror.ServiceError());
            }
        }
    }
}
