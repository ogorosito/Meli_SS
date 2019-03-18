using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Services
{
    public interface IConsultaClimaService
    {
        int ObtenerCantidadPeriodosDeLluvia();
        int ObtenerDiaPicoMaximoDeLluvia();

        int ObtenerCantidadPeriodosDeSequia();

        int ObtenerCantidadPeriodosDeCondicionesOptimas();

    }
}
