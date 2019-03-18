using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models.Factories
{
    public abstract class PlanetaFactory
    {
        public abstract Planeta CrearPlaneta();
    }
}
