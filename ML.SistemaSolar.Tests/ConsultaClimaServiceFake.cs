using ML.SistemaSolar.EF;
using ML.SistemaSolar.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ML.SistemaSolar.Tests
{
    public class ConsultaClimaServiceFake : IConsultaClimaService
    {
        private readonly IList<CondicionClimatica> condicionesClimaticas;

        public ConsultaClimaServiceFake()
        {
            condicionesClimaticas = new List<CondicionClimatica>()
            {
                new CondicionClimatica{ Dia = 0, EsPeriodoDeLluvia = false, EsPeriodoDeSequia= true, HayCondicionesOptimasDeTemperatura =false, PerimetroTriangulo = 0},
                new CondicionClimatica{ Dia = 1, EsPeriodoDeLluvia = true, EsPeriodoDeSequia= false, HayCondicionesOptimasDeTemperatura =false, PerimetroTriangulo = 100},
                new CondicionClimatica{ Dia = 2, EsPeriodoDeLluvia = false, EsPeriodoDeSequia= false, HayCondicionesOptimasDeTemperatura =false, PerimetroTriangulo = 0},
                new CondicionClimatica{ Dia = 3, EsPeriodoDeLluvia = true, EsPeriodoDeSequia= false, HayCondicionesOptimasDeTemperatura =false, PerimetroTriangulo = 200},
                new CondicionClimatica{ Dia = 4, EsPeriodoDeLluvia = false, EsPeriodoDeSequia= false, HayCondicionesOptimasDeTemperatura =true, PerimetroTriangulo = 0}
            };
        }

        public int ObtenerCantidadPeriodosDeCondicionesOptimas()
        {
            throw new NotImplementedException();
        }

        public int ObtenerCantidadPeriodosDeLluvia()
        {
            throw new NotImplementedException();
        }

        public int ObtenerCantidadPeriodosDeSequia()
        {
            throw new NotImplementedException();
        }

        public CondicionClimatica ObtenerCondicionClimaticaPorDia(int dia)
        {
            return condicionesClimaticas.FirstOrDefault(c => c.Dia == dia);
        }

        public int ObtenerDiaPicoMaximoDeLluvia()
        {
            throw new NotImplementedException();
        }
    }
}
