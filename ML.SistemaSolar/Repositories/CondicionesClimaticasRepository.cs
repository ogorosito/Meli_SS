using Microsoft.EntityFrameworkCore;
using ML.SistemaSolar.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Repositories
{
    /// <summary>
    /// Repositorio de Condiciones Climaticas.
    /// </summary>
    public class CondicionClimaticaRepository : BaseRepository<CondicionClimatica>, ICondicionClimaticaRepository
    {
        public CondicionClimaticaRepository(CondicionClimaticaContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
