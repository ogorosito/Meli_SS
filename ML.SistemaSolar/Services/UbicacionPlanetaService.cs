using ML.SistemaSolar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Services
{
    public class UbicacionPlanetaService : IUbicacionPlanetaService
    {
        public UbicacionPlanetaService()
        {
        }

        public Ubicacion ObtenerCoordenadas(IPlaneta planeta)
        {
            return new Ubicacion(planeta.DistanciaAlSol * Math.Cos(GradosRadianesConverter(planeta.PosicionEnGrados)), planeta.DistanciaAlSol * Math.Sin(GradosRadianesConverter(planeta.PosicionEnGrados)));
        }

        public Ubicacion ObtenerCoordenadasSol()
        {
            return new Ubicacion(0, 0);
        }

        private double GradosRadianesConverter(double grados)
        {
            return grados * Math.PI / 180.0;

        }
    }
}
