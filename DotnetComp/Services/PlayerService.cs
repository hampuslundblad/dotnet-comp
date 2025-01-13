using System.Linq;
using System.Net;
using Microsoft.OpenApi.Any;
using DotnetComp.Clients;
using DotnetComp.Errors;
using DotnetComp.Mappers;
using DotnetComp.Models.Domain;
using DotnetComp.Results;
using DotnetComp.Repositories;


namespace DotnetComp.Services
{
    public interface IPlayerService
    {
        Task<Result<Player>> GetPlayer(int id);
    }
    public class PlayerService(ILogger<PlayerService> logger, IPlayerRepository playerRepository)
    {
        private readonly IPlayerRepository playerRepository = playerRepository;
        private readonly ILogger<PlayerService> logger = logger;


        public async Task<Result<Player>> GetPlayer(int id)
        {
            var player = await playerRepository.GetById(id);
            if (player == null)
            {
                return Result<Player>.Failure(PlayerError.NotFound());
            }
            else
            {
                return Result<Player>.Success(Player.ToDomain(player));
            }
        }
    }

}