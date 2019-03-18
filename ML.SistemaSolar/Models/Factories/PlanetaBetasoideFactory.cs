using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models.Factories
{
    public class PlanetaBetasoideFactory : PlanetaFactory
    {
        public override Planeta CrearPlaneta()
        {
            return new Betasoide();
        }
    }
}
