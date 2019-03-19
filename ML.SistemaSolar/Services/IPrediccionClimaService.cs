using ML.SistemaSolar.EF;
using ML.SistemaSolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Services
{
    /// <summary>
    /// Interface del service de generacion de prediccion de clima.
    /// </summary>
    public interface IPrediccionClimaService
    {

        bool PredecirClima(DateTime fechaInicio, DateTime fechaFin);

        bool HayCondicionesOptimasDeTemperatura(Galaxia galaxia);
        bool EsPeriodoDeSequia(Galaxia galaxia);

        PeriodoDeLluvia EsPeriodoDeLluvia(Galaxia galaxia);

    }
}
