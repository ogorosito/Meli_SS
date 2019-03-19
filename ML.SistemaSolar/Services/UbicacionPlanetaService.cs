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

        /// <summary>
        /// Obtengo las coordenadas del planeta
        /// http://repositorio.pucp.edu.pe/index/bitstream/handle/123456789/28688/introduccion_al_analisis_cap04.pdf?sequence=10
        /// Pag 200
        /// </summary>
        /// <param name="planeta"></param>
        /// <returns>Devuelve la ubicacion del planeta.</returns>
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
