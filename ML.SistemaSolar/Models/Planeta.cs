using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    /// <summary>
    /// Clase Base-Planeta
    /// </summary>
    public abstract class Planeta : IPlaneta
    {
        public Planeta()
        {
            VelocidadAngular = CrearVelocidadAngular();
        }


        protected abstract VelocidadAngular CrearVelocidadAngular();

        /// <summary>
        /// Determina a cuantos grados por dia gira el planeta y en que sentido (horario, antihorario)
        /// </summary>
        /// <returns></returns>
        private VelocidadAngular VelocidadAngular { get; }

        /// <summary>
        /// Distancia respecto al sol. Está tomada en escala 1:100
        /// </summary>
        public abstract int DistanciaAlSol { get; }

        /// <summary>
        /// Posicion actual del planeta (0-360 grados)
        /// </summary>
        public int PosicionEnGrados { get; private set; }


        /// <summary>
        /// Gira el planeta de acuerdo a la velocidad angular.
        /// </summary>
        public void Girar()
        {
            PosicionEnGrados += VelocidadAngular.SentidoGiro == SentidoGiro.Antihorario ? VelocidadAngular.GradosPorDia : -VelocidadAngular.GradosPorDia;

            //Valida que la posicion del planeta sea entre 0 grados y 359.
            //Posible refactoring.
            if (PosicionEnGrados < 0)
            {
                PosicionEnGrados = 360 + PosicionEnGrados;
            }
            if (PosicionEnGrados >= 360)
            {
                PosicionEnGrados = PosicionEnGrados - 360;
            }
        }
    }
}
