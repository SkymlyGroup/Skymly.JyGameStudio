using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skymly.JyGameTools.Models;

namespace Skymly.JyGameStudio.Api.Data
{
    public class ScriptsContext : DbContext
    {
        public ScriptsContext (DbContextOptions<ScriptsContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Aoyi> Aoyis { get; set; }

        public DbSet<AoyiCondition> AoyiConditions { get; set; }
    }
}
