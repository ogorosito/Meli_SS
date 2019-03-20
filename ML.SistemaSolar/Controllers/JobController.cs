using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ML.SistemaSolar.DTOs;
using ML.SistemaSolar.Services;

namespace ML.SistemaSolar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private const string JobExecuteResponse_Respuesta = "Job ejecutado correctamente.";

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
        [HttpPost]
        public JobExecuteResponse Execute()
        {
            try
            {
                var hoy = DateTime.Today;
                var diezAnosDespues = hoy.AddYears(10);

                prediccionClimaService.PredecirClima(hoy, diezAnosDespues);

                return new JobExecuteResponse { Ok = true, Respuesta = JobExecuteResponse_Respuesta };
            }
            catch (Exception e)
            {
                return new JobExecuteResponse { Ok = false, Respuesta = e.Message };
            }

        }
    }
}