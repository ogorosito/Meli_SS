using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Repositories
{
    public interface IRepositoryWrapper
    {
        ICondicionClimaticaRepository CondicionClima { get; }
    }
}
