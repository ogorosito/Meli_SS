using System.Drawing;
using ML.SistemaSolar.Models;

namespace ML.SistemaSolar.Services
{
    /// <summary>
    /// Interface del servicio de mapeo de ubicacion grados-distancia a ubicacion en el plano.
    /// </summary>
    public interface IUbicacionPlanetaService
    {
        Ubicacion ObtenerCoordenadas(IPlaneta planeta);
        Ubicacion ObtenerCoordenadasSol();
    }
}