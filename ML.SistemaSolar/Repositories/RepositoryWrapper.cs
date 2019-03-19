using ML.SistemaSolar.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Repositories
{
    /// <summary>
    /// Implementacin de Wrapper del repo.
    /// </summary>
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CondicionClimaticaContext repoContext;
        private ICondicionClimaticaRepository condicionClimatica;

        public RepositoryWrapper(CondicionClimaticaContext repoContext)
        {
            this.repoContext = repoContext;
        }

        public ICondicionClimaticaRepository CondicionClima
        {
            get
            {
                if (condicionClimatica == null)
                    condicionClimatica = new CondicionClimaticaRepository(repoContext);

                return condicionClimatica;
            }
        }
    }
}
