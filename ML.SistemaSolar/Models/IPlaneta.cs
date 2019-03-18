using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Models
{
    public interface IPlaneta
    {
        int DistanciaAlSol { get; }
        int PosicionEnGrados { get; }
    }
}
