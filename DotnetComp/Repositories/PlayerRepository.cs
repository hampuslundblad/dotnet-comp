using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetComp.Data;
using DotnetComp.Models.Entities;

namespace DotnetComp.Repositories
{

    public interface IPlayerRepository
    {
        IEnumerable<PlayerEntity> GetAll();

        Task<PlayerEntity?> GetById(int PlayerId);
    }
    public class PlayerRepository(DatabaseContext dbContext) : IPlayerRepository
    {
        private readonly DatabaseContext dbContext = dbContext;

        public IEnumerable<PlayerEntity> GetAll()
        {
            return dbContext.Players.ToList();
        }

        public async Task<PlayerEntity?> GetById(int PlayerId)
        {
            return await dbContext.Players.FindAsync(PlayerId);
        }
    }
}