using System;
using System.Collections.Generic;
using DotnetComp.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace DotnetComp.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public required DbSet<PlayerEntity> Players { get; set; }
        public required DbSet<GroupEntity> Groups { get; set; }
    }

}