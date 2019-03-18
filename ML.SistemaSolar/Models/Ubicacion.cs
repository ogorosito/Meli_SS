using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    public class Ubicacion
    {
        public Ubicacion(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }
    }
}
