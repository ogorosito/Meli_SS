using ML.SistemaSolar.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    public class Galaxia
    {
        public Galaxia()
        {
            Vulcano = new PlanetaVulcanoFactory().CrearPlaneta();
            Ferengi = new PlanetaFerengiFactory().CrearPlaneta();
            Betasoide = new PlanetaBetasoideFactory().CrearPlaneta();

        }
        public Planeta Vulcano { get; set; }

        public Planeta Ferengi { get; set; }

        public Planeta Betasoide { get; set; }

        public void GirarPlanetas()
        {
            Vulcano.Girar();
            Ferengi.Girar();
            Betasoide.Girar();
        }
    }
}
