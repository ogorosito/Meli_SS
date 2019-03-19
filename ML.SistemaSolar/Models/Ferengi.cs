using ML.SistemaSolar.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    /// <summary>
    /// Planeta Ferengi
    /// </summary>
    public class Ferengi: Planeta
    {
        public override int DistanciaAlSol => 5;

        protected override VelocidadAngular CrearVelocidadAngular()
        {
            return new VelocidadAngularFactory().CrearVelocidadAngular(1, SentidoGiro.Horario);
        }
    }
}
