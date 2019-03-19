using ML.SistemaSolar.EF;
using ML.SistemaSolar.Models;
using ML.SistemaSolar.Models.Factories;
using ML.SistemaSolar.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Services
{
    public class PrediccionClimaService : IPrediccionClimaService
    {

        private readonly IUbicacionPlanetaService ubicacionPlanetaService;
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly Galaxia galaxia;

        public PrediccionClimaService(IUbicacionPlanetaService ubicacionPlanetaService, IRepositoryWrapper repositoryWrapper)
        {
            this.ubicacionPlanetaService = ubicacionPlanetaService;
            this.repositoryWrapper = repositoryWrapper;
            this.galaxia = new GalaxiaFactory().CrearGalaxia();
        }

        /// <summary>
        /// Elimina los datos existentes y agrega nuevos datos entre las fechas establecidas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio</param>
        /// <param name="fechaFin">Fecha de fin</param>
        /// <returns>Operacion exitosa</returns>

        public bool PredecirClima(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var repositorio = repositoryWrapper.CondicionClima;

                //Elimino toda la info.
                foreach (var item in repositorio.FindAll())
                {
                    repositorio.Delete(item);
                }
                repositorio.Save();

                //hago el loop de los dias enviados como parametro.
                var i = 0;
                for (DateTime fecha = fechaInicio; fecha.Date <= fechaFin.Date; fecha = fecha.AddDays(1))
                {
                    //Creo la condicion climatica
                    var condicionClimatica = EvalucionCondicionClimatica(galaxia);
                    condicionClimatica.Dia = i;

                    //Agrego la condicion climatica al repo.
                    repositorio.Create(condicionClimatica);

                    //Giro los planetas.
                    galaxia.GirarPlanetas();

                    //Incremento el dia.
                    i++;
                }

                //Persisto en el repo.
                repositorio.Save();

                return true;
            }
            catch (Exception e)
            {
                ///TODO --> agregar la exception al log.
                return false;                
            }
           
        }

        private CondicionClimatica EvalucionCondicionClimatica(Galaxia galaxia)
        {
            var condicionClimatica = new CondicionClimatica();


            //Verifica si es periodo de sequia.
            if (EsPeriodoDeSequia(galaxia))
            {
                condicionClimatica.EsPeriodoDeSequia = true;
                Debug.WriteLine("PERIODO DE SEQUIA!!");
            }
            else
            {              

                //Verifica si hay condiciones optimas de temperatura y presion.
                if (HayCondicionesOptimasDeTemperatura(galaxia))
                {
                    condicionClimatica.HayCondicionesOptimasDeTemperatura = true;
                    Debug.WriteLine("CONDICIONES OPTIMAS DE TEMPERATURA");
                }
                else
                {
                    //Verifica si es periodo de lluvia.
                    var periodoDeLluvia = EsPeriodoDeLluvia(galaxia);
                    if (periodoDeLluvia.EsPeriodoDeLluvia)
                    {
                        condicionClimatica.EsPeriodoDeLluvia = true;
                        condicionClimatica.PerimetroTriangulo = periodoDeLluvia.PerimetroTriangulo;

                        Debug.WriteLine($"PERIODO DE LLUVIA!! - PERIMETRO --> {periodoDeLluvia.PerimetroTriangulo}");
                    }
                }
            }



            return condicionClimatica;
        }

        public bool HayCondicionesOptimasDeTemperatura(Galaxia galaxia)
        {
            //Obtiene la obicacion de los 3 planetas y el sol
            var ubicacionBetasoide = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Betasoide);


            var ubicacionFerengi = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Ferengi);


            var ubicacionVulcano = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Vulcano);


            var ubicacionSol = ubicacionPlanetaService.ObtenerCoordenadasSol();

            //Verifica si los 3 planetas estan alineados.
            if (EstanLosCuerposAlineados(ubicacionBetasoide, ubicacionFerengi, ubicacionVulcano))
            {
                //Si estan los planetas alineados verifico que no esten alineados al sol.
                return !EstanLosCuerposAlineados(ubicacionBetasoide, ubicacionFerengi, ubicacionSol);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si es un periodo de sequia en la Galaxia
        /// </summary>
        /// <param name="galaxia">Galaxia a verificar</param>
        /// <returns>Es Periodo de sequia o no</returns>
        public bool EsPeriodoDeSequia(Galaxia galaxia)
        {
            //Obtiene la obicacion de los 3 planetas y el sol
            var ubicacionBetasoide = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Betasoide);

            var ubicacionFerengi = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Ferengi);

            var ubicacionVulcano = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Vulcano);

            var ubicacionSol = ubicacionPlanetaService.ObtenerCoordenadasSol();

            //Verifica si los 3 planetas estan alineados. Luego verifica si 2 de ellos estan alineados respecto al sol.
            return EstanLosCuerposAlineados(ubicacionBetasoide, ubicacionFerengi, ubicacionVulcano) && EstanLosCuerposAlineados(ubicacionBetasoide, ubicacionFerengi, ubicacionSol);
        }

        public PeriodoDeLluvia EsPeriodoDeLluvia(Galaxia galaxia)
        {
            if (EstaSolDentroTrianguloFormadoPorPlanetas(galaxia))
            {
                return ObtenerPerimetroTriangulo(galaxia);
            }
            else
            {
                return PeriodoDeLluvia.SinPeriodoDeLluvia();
            }
        }

        /// <summary>
        /// Verifica que el sol esté dentro del triangulo formado por los planetas
        /// http://www.dma.fi.upm.es/personal/mabellanas/tfcs/kirkpatrick/Aplicacion/algoritmos.htm
        /// </summary>
        /// <param name="galaxia">Galaxia a verificar</param>
        /// <returns></returns>
        private bool EstaSolDentroTrianguloFormadoPorPlanetas(Galaxia galaxia)
        {
            //Obtiene la obicacion de los 3 planetas y el sol
            var ubicacionBetasoide = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Betasoide);
            //Debug.WriteLine($"Distancia al sol --> {galaxia.Betasoide.DistanciaAlSol} - Posicion en grados --> {galaxia.Betasoide.PosicionEnGrados}");
            //Debug.WriteLine($"Betasoide ({ubicacionBetasoide.X}, {ubicacionBetasoide.Y})");

            var ubicacionFerengi = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Ferengi);
            //Debug.WriteLine($"Distancia al sol --> {galaxia.Ferengi.DistanciaAlSol} - Posicion en grados --> {galaxia.Ferengi.PosicionEnGrados}");
            //Debug.WriteLine($"Ferengi ({ubicacionFerengi.X}, {ubicacionFerengi.Y})");

            var ubicacionVulcano = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Vulcano);
            //Debug.WriteLine($"Distancia al sol --> {galaxia.Vulcano.DistanciaAlSol} - Posicion en grados --> {galaxia.Vulcano.PosicionEnGrados}");
            //Debug.WriteLine($"Vulcano ({ubicacionVulcano.X}, {ubicacionVulcano.Y})");

            var ubicacionSol = ubicacionPlanetaService.ObtenerCoordenadasSol();

            var orientacion1 = ObtenerOrientacionTriangulo(ubicacionBetasoide, ubicacionFerengi, ubicacionVulcano);
            var orientacion2 = ObtenerOrientacionTriangulo(ubicacionBetasoide, ubicacionFerengi, ubicacionSol);
            var orientacion3 = ObtenerOrientacionTriangulo(ubicacionFerengi, ubicacionVulcano, ubicacionSol);
            var orientacion4 = ObtenerOrientacionTriangulo(ubicacionVulcano, ubicacionBetasoide, ubicacionSol);

            return (orientacion1 == orientacion2 && orientacion1 == orientacion3 && orientacion1 == orientacion4);
        }

        private OrientacionTriangulo ObtenerOrientacionTriangulo(Ubicacion ubicacion1, Ubicacion ubicacion2, Ubicacion ubicacion3)
        {
            return double.IsNegative((ubicacion1.X - ubicacion3.X) * (ubicacion2.Y - ubicacion3.Y) - (ubicacion1.Y - ubicacion3.Y) * (ubicacion2.X - ubicacion3.X)) ? OrientacionTriangulo.Negativa : OrientacionTriangulo.Positiva;
        }


        /// <summary>
        /// Obtiene el perimetro del triangulo formado por los planetas
        /// </summary>
        /// <param name="galaxia"></param>
        /// <returns></returns>
        private PeriodoDeLluvia ObtenerPerimetroTriangulo(Galaxia galaxia)
        {
            //Obtiene la obicacion de los 3 planetas
            var ubicacionBetasoide = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Betasoide);
            var ubicacionFerengi = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Ferengi);
            var ubicacionVulcano = ubicacionPlanetaService.ObtenerCoordenadas(galaxia.Vulcano);

            var distanciaBetasoideFerengi = DistanciaEntreDosPuntos(ubicacionBetasoide, ubicacionFerengi);
            var distanciaFerengiVulcano = DistanciaEntreDosPuntos(ubicacionFerengi, ubicacionVulcano);
            var distanciaBetasoideVulcano = DistanciaEntreDosPuntos(ubicacionBetasoide, ubicacionVulcano);

            return new PeriodoDeLluvia
            {
                EsPeriodoDeLluvia = true,
                PerimetroTriangulo = distanciaBetasoideFerengi + distanciaFerengiVulcano + distanciaBetasoideVulcano
            };
        }

        /// <summary>
        /// Obtengo la distancia entre 2 planetas
        /// https://www.sangakoo.com/es/temas/distancia-entre-dos-puntos-en-el-espacio
        /// </summary>
        /// <param name="ubicacion1">Ubicacion planeta 1</param>
        /// <param name="ubicacion2">Ubicacion planeta 2</param>
        /// <returns></returns>
        private double DistanciaEntreDosPuntos(Ubicacion ubicacion1, Ubicacion ubicacion2)
        {
            return Math.Sqrt(Math.Pow(ubicacion2.X - ubicacion1.X, 2) + Math.Pow(ubicacion2.Y - ubicacion1.Y, 2));
        }


        /// <summary>
        /// Devuelve si los 3 cuerpos (planeta o sol) estan alineados 
        /// https://www.unprofesor.com/matematicas/como-comprobar-si-tres-puntos-estan-alineados-1640.html
        /// </summary>
        /// <param name="ubicacion1">Ubicacion del cuerpo 1</param>
        /// <param name="ubicacion2">Ubicacion del cuerpo 2</param>
        /// <param name="ubicacion3">Ubicacion del cuerpo 3</param>
        /// <returns></returns>
        private bool EstanLosCuerposAlineados(Ubicacion ubicacion1, Ubicacion ubicacion2, Ubicacion ubicacion3)
        {
            var segmentoAB = new Ubicacion(ubicacion2.X - ubicacion1.X, ubicacion2.Y - ubicacion1.Y);
            var segmentoAC = new Ubicacion(ubicacion3.X - ubicacion1.X, ubicacion3.Y - ubicacion1.Y);

            var direccion = (segmentoAB.X * segmentoAC.Y - segmentoAB.Y * segmentoAC.X);

            //Al convertir de Grados + Distancia a Radianes se pierde precision en el calulo de la posicion.
            return Math.Round(direccion, 5) == 0;
        }
    }
}
