using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ML.SistemaSolar.Services;

namespace ML.SistemaSolar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IPrediccionClimaService prediccionClimaService;


        /// <summary>
        /// Job Controller 
        /// </summary>
        /// <param name="prediccionClimaService">Servicio de Prediccion de Clima</param>
        public JobController(IPrediccionClimaService prediccionClimaService)
        {
            this.prediccionClimaService = prediccionClimaService;
        }

        /// <summary>
        /// Ejecuta el Job de Prediccion de Clima durante 10 años.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public bool Execute()
        {
            var hoy = DateTime.Today;
            var diezAnosDespues = hoy.AddYears(10);

            return prediccionClimaService.PredecirClima(hoy, diezAnosDespues);
        }
    }
}