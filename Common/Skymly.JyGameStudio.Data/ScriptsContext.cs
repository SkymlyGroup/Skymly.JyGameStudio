using Microsoft.EntityFrameworkCore;

using Skymly.JyGameStudio.Models;

using System;
using System.Collections.Generic;

namespace Skymly.JyGameStudio.Data
{
    public class ScriptsContext : DbContext
    {
        public ScriptsContext(DbContextOptions<ScriptsContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

       
        public DbSet<Aoyi> Aoyi { get; set; }

        public DbSet<Battle> Battle { get; set; }
        public DbSet<BattleRole> BattleRole { get; set; }

        public DbSet<AoyiCondition> AoyiCondition { get; set; }
    }
}
