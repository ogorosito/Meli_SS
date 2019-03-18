using ML.SistemaSolar.Models.Factories;
using ML.SistemaSolar.Services;
using System;
using System.Diagnostics;
using System.Linq;

namespace ML.SistemaSolar.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IUbicacionPlanetaService ubicacionPlanetaService = new UbicacionPlanetaService();
            IPrediccionClimaService prediccionClimaService = new PrediccionClimaService(ubicacionPlanetaService);

            var hoy = DateTime.Today;
            var diezAnosDespues = hoy.AddYears(1);

               prediccionClimaService.PredecirClima(hoy, diezAnosDespues);

            var galaxia =  new GalaxiaFactory().CrearGalaxia();

            
           // //step 5
            while (galaxia.Vulcano.PosicionEnGrados != 0)
                galaxia.Vulcano.Girar();

           // //step 1
           // while (galaxia.Ferengi.PosicionEnGrados != 0)
           //     galaxia.Ferengi.Girar();

           // //step 3
           // while (galaxia.Betasoide.PosicionEnGrados != 0)
           //     galaxia.Betasoide.Girar();

           //System.Console.WriteLine(prediccionClimaService.EsPeriodoDeSequia(galaxia));



            //foreach (var condicionClima in prediccionClimaService.PredecirClima(hoy, diezAnosDespues).Select((item, i) => new { i, item }))
            //{
            //    //   System.Console.WriteLine($" Dia --> {condicionClima.i} - P_SE_ --> {condicionClima.item.EsPeriodoDeSequia} - P_LL_ --> {condicionClima.item.EsPeriodoDeLluvia} - PER_TRI --> {condicionClima.item.PerimetroTriangulo} - ");
            //}

            System.Console.ReadLine();
        }
    }
}
