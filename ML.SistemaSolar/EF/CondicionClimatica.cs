using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.EF
{
    public class CondicionClimatica
    {

        public CondicionClimatica()
        {
            Dia = 0;
            HayCondicionesOptimasDeTemperatura = false;
            EsPeriodoDeLluvia = false;
            EsPeriodoDeSequia = false;
            PerimetroTriangulo = 0;

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dia { get; set; }

        public bool HayCondicionesOptimasDeTemperatura { get; set; }

        public bool EsPeriodoDeSequia { get; set; }

        public bool EsPeriodoDeLluvia { get; set; }

        public double PerimetroTriangulo { get; set; }

    }
}
