using ML.SistemaSolar.Models;
using ML.SistemaSolar.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ML.SistemaSolar.Tests
{
    public class PrediccionClimaServiceFake : IPrediccionClimaService
    {
        public PeriodoDeLluvia EsPeriodoDeLluvia(Galaxia galaxia)
        {
            throw new NotImplementedException();
        }

        public bool EsPeriodoDeSequia(Galaxia galaxia)
        {
            throw new NotImplementedException();
        }

        public bool HayCondicionesOptimasDeTemperatura(Galaxia galaxia)
        {
            throw new NotImplementedException();
        }

        public bool PredecirClima(DateTime fechaInicio, DateTime fechaFin)
        {
            return true;
        }
    }
}
