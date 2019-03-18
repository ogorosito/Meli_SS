using System.Drawing;
using ML.SistemaSolar.Models;

namespace ML.SistemaSolar.Services
{
    public interface IUbicacionPlanetaService
    {
        Ubicacion ObtenerCoordenadas(IPlaneta planeta);
        Ubicacion ObtenerCoordenadasSol();
    }
}