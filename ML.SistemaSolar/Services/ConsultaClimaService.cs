using ML.SistemaSolar.EF;
using ML.SistemaSolar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Services
{
    public class ConsultaClimaService : IConsultaClimaService
    {
        private readonly ICondicionClimaticaRepository condicionClimaticaRepository;

        public ConsultaClimaService(IRepositoryWrapper repositoryWrapper)
        {
            condicionClimaticaRepository = repositoryWrapper.CondicionClima;
        }

        public int ObtenerCantidadPeriodosDeLluvia()
        {
            return ObtenerCantidadPeriodosPorCondicion(c => c.EsPeriodoDeLluvia);
        }

        public int ObtenerCantidadPeriodosDeSequia()
        {
            return ObtenerCantidadPeriodosPorCondicion(c => c.EsPeriodoDeSequia);
        }

        private int ObtenerCantidadPeriodosPorCondicion(Expression<Func<CondicionClimatica, bool>> expression)
        {
            var condicionesPeriodoLluvia = condicionClimaticaRepository.FindAll().Where(expression);
            return condicionesPeriodoLluvia.Where(c => !condicionesPeriodoLluvia.Any(c2 => c2.Dia == c.Dia + 1)).Count();
        }

        public int ObtenerDiaPicoMaximoDeLluvia()
        {
            var diaMaximoLluvia = condicionClimaticaRepository.FindAll().Where(c => c.EsPeriodoDeLluvia).OrderByDescending(c => c.PerimetroTriangulo).FirstOrDefault();

            return diaMaximoLluvia?.Dia ?? -1;
        }

        public int ObtenerCantidadPeriodosDeCondicionesOptimas()
        {
            return ObtenerCantidadPeriodosPorCondicion(c => c.HayCondicionesOptimasDeTemperatura);
        }

        public CondicionClimatica ObtenerCondicionClimaticaPorDia(int dia)
        {
            return  condicionClimaticaRepository.FindAll().Where(d => d.Dia == dia).SingleOrDefault();
        }
    }
}
