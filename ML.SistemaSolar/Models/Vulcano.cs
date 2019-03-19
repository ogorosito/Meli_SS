using ML.SistemaSolar.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    /// <summary>
    /// Planeta Vulcano.
    /// </summary>
    public class Vulcano: Planeta
    {
        public override int DistanciaAlSol => 10;

        protected override VelocidadAngular CrearVelocidadAngular()
        {
            return new VelocidadAngularFactory().CrearVelocidadAngular(5, SentidoGiro.Antihorario);
        }
    }
}
