using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    public abstract class Planeta : IPlaneta
    {
        public Planeta()
        {
            VelocidadAngular = CrearVelocidadAngular();
        }

        protected abstract VelocidadAngular CrearVelocidadAngular();
        private VelocidadAngular VelocidadAngular { get; }
        public abstract int DistanciaAlSol { get; }
        public int PosicionEnGrados { get; private set; }


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
