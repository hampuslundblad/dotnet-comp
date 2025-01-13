using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetComp.Models.Entities;

namespace DotnetComp.Models.Domain
{
    public class Player
    {
        public required string PlayerName { get; set; }
        public int ExperienceGainedLast24H { get; set; }
        public int ExperienceGainedLastWeek { get; set; }

        public int TotalExperience { get; set; }

        public static Player ToDomain(PlayerEntity playerEntity)
        {
            return new Player
            {
                PlayerName = playerEntity.PlayerName,
                ExperienceGainedLast24H = playerEntity.ExperienceGainedLast24H,
                ExperienceGainedLastWeek = playerEntity.ExperienceGainedLastWeek,
            };
        }
    }
}