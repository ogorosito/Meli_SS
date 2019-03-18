using ML.SistemaSolar.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    public class Betasoide : Planeta
    {
        public override int DistanciaAlSol => 20;

        protected override VelocidadAngular CrearVelocidadAngular()
        {
            return new VelocidadAngularFactory().CrearVelocidadAngular(3, SentidoGiro.Horario);
        }
    }
}
