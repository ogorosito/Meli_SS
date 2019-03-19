using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Repositories
{
    /// <summary>
    /// Interface Wrapper de los repo.
    /// </summary>
    public interface IRepositoryWrapper
    {
        ICondicionClimaticaRepository CondicionClima { get; }
    }
}
