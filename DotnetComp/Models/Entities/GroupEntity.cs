using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetComp.Models.Entities
{
    public class GroupEntity
    {
        [Key]
        public int GroupId { get; set; }
        public required string GroupName { get; set; }
        public List<PlayerEntity> Players { get; set; } = [];



    }
}