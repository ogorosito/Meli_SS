using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models.Factories
{
    public class VelocidadAngularFactory
    {

        public VelocidadAngular CrearVelocidadAngular(int gradosPorDia, SentidoGiro sentidoGiro)
        {
            return new VelocidadAngular
            {
                GradosPorDia = gradosPorDia,
                SentidoGiro = sentidoGiro
            };
        }

    }
}
