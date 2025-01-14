using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetComp.Models.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int PlayerId { get; set; }
        [MinLength(3), MaxLength(128)]
        public required string PlayerName { get; set; }
        public int ExperienceGainedLast24H { get; set; }
        public int ExperienceGainedLastWeek { get; set; }

        public int TotalExperience { get; set; }
    }
}