using Microsoft.EntityFrameworkCore;
using ML.SistemaSolar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ML.SistemaSolar.EF
{
    public class CondicionClimaticaContext: DbContext
    {
        public CondicionClimaticaContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<CondicionClimatica> CondicionesClimaticas { get; set; }
    }
}
