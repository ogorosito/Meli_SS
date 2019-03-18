using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    public class PeriodoDeLluvia
    {
        public bool EsPeriodoDeLluvia { get; set; }

        public double PerimetroTriangulo { get; set; }

        public static PeriodoDeLluvia SinPeriodoDeLluvia()
        {
            return new PeriodoDeLluvia
            {
                EsPeriodoDeLluvia = false,
                PerimetroTriangulo = 0
            };

        }
    }
}
