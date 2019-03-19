using ML.SistemaSolar.EF;
using ML.SistemaSolar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Services
{
    /// <summary>
    /// Servicio de consulta de condiciones climaticas.
    /// </summary>
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

        /// <summary>
        /// Obtiene  la cantidad de periodos aplicando el filtro enviado como parametro.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private int ObtenerCantidadPeriodosPorCondicion(Expression<Func<CondicionClimatica, bool>> expression)
        {
            ///Obtiene todos los registros aplicadndo la condicion enviada como parametro. Ej: EsPeriodoDeLluvia == true.
            var condicionesPeriodoLluvia = condicionClimaticaRepository.FindAll().Where(expression);

            //Cuando no existe un dia de lluvia es que terminó el periodo de lluvia y empieza otro.
            //Ej. Si llueve el dia 1, 2, 3, 4 (periodo 1) y el 7, 8, 9 (periodo 2), pero no llueve el dia 5 ni 6 hay 2 periodos de lluvia.
            return condicionesPeriodoLluvia.Where(c => !condicionesPeriodoLluvia.Any(c2 => c2.Dia == c.Dia + 1)).Count();
        }

        /// <summary>
        /// Obtiene el dia que tiene el pico maximo de lluvia.
        /// </summary>
        /// <returns></returns>
        public int ObtenerDiaPicoMaximoDeLluvia()
        {
            ///Toma todos los dias con lluvia, los ordena de forma descendiente y toma el priemero.
            var diaMaximoLluvia = condicionClimaticaRepository.FindAll().Where(c => c.EsPeriodoDeLluvia).OrderByDescending(c => c.PerimetroTriangulo).FirstOrDefault();

            ///Si no llovió ningun dia devuelvo -1.
            return diaMaximoLluvia?.Dia ?? -1;
        }

        public int ObtenerCantidadPeriodosDeCondicionesOptimas()
        {
            return ObtenerCantidadPeriodosPorCondicion(c => c.HayCondicionesOptimasDeTemperatura);
        }

        /// <summary>
        /// Obtiene la condicion climatica de un dia-.
        /// </summary>
        /// <param name="dia">dia de consulta,</param>
        /// <returns>Info con la condicion climatica.</returns>
        public CondicionClimatica ObtenerCondicionClimaticaPorDia(int dia)
        {
            return  condicionClimaticaRepository.FindAll().Where(d => d.Dia == dia).SingleOrDefault();
        }
    }
}
