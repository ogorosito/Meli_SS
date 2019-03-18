using ML.SistemaSolar.EF;
using ML.SistemaSolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Services
{
    public interface IPrediccionClimaService
    {
        /// <summary>
        /// Elimina los datos existentes y agrega nuevos datos entre las fechas establecidas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio</param>
        /// <param name="fechaFin">Fecha de fin</param>
        /// <returns>Operacion exitosa</returns>
        bool PredecirClima(DateTime fechaInicio, DateTime fechaFin);

        bool HayCondicionesOptimasDeTemperatura(Galaxia galaxia);
        bool EsPeriodoDeSequia(Galaxia galaxia);

        PeriodoDeLluvia EsPeriodoDeLluvia(Galaxia galaxia);

    }
}
