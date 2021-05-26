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

        public DbSet<Aoyi> Aoyis { get; set; }

        public DbSet<AoyiCondition> AoyiConditions { get; set; }
    }
}
