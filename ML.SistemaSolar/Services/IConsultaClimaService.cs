using ML.SistemaSolar.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Services
{
    /// <summary>
    /// Interface del service de consulta de condiciones climaticas.
    /// </summary>
    public interface IConsultaClimaService
    {
        int ObtenerCantidadPeriodosDeLluvia();
        int ObtenerDiaPicoMaximoDeLluvia();

        int ObtenerCantidadPeriodosDeSequia();

        int ObtenerCantidadPeriodosDeCondicionesOptimas();

        CondicionClimatica ObtenerCondicionClimaticaPorDia(int dia);

    }
}
