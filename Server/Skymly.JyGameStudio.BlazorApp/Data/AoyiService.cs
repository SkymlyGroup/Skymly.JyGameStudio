using Microsoft.EntityFrameworkCore;

using Skymly.JyGameStudio.Data;
using Skymly.JyGameTools.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.Data
{
    public class AoyiService
    {
        readonly ScriptsContext _context;
        public AoyiService(ScriptsContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Aoyi>> Get()
        {
            return await _context.Aoyis.Include(v => v.AoyiConditions).ToListAsync();
        }



    }
}
