using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    /// <summary>
    /// Velocidad angular del planeta
    /// </summary>
    public class VelocidadAngular
    {
        /// <summary>
        /// Grados por dia que gira el planeta
        /// </summary>
        public int GradosPorDia { get; set; }

        /// <summary>
        /// Sentido de giro del planeta.
        /// </summary>
        public SentidoGiro SentidoGiro { get; set; }
    }
}
