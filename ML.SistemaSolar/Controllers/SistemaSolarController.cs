using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ML.SistemaSolar.DTOs;
using ML.SistemaSolar.EF;
using ML.SistemaSolar.Services;

namespace ML.SistemaSolar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SistemaSolarController : ControllerBase
    {

        private const string Problem_Title = "No hay información disponible para el día solicitado.";
        private const string Problem_Detail = "";

        private readonly IConsultaClimaService consultaClimaService;
        private readonly IMapper mapper;

        public SistemaSolarController(IConsultaClimaService consultaClimaService, IMapper mapper)
        {
            this.consultaClimaService = consultaClimaService;
            this.mapper = mapper;
        }


        /// <summary>
        /// Obtiene la informacion del clima para un dia determinado.
        /// En caso que el dia enviado en el request no sea valido devuelve el mensaje indicando el error.
        /// </summary>
        /// <param name="dia">Dia a consultar</param>
        /// <returns>Informacion de respuesta</returns>
        [HttpGet]
        public IActionResult Clima([FromQuery]int dia)
        {
            var condicionClima = consultaClimaService.ObtenerCondicionClimaticaPorDia(dia);

            if (condicionClima != null)
            {
                return Ok(mapper.Map<CondicionClimatica, ClimaResponse>(condicionClima));
            }
            else
            {
                var details = new ProblemDetails()
                {
                    Type = string.Empty,
                    Title = Problem_Title,
                    Detail = Problem_Detail,
                    Instance = Url.Action("Clima", "SistemaSolar", new { dia = dia }),
                    Status = 404
                };
                return new ObjectResult(details)
                {
                    ContentTypes = { "application/problem+json" },
                    StatusCode = 404,
                };
            }
        }

        /// <summary>
        /// Devuelve la cantidad de periodos de Lluvia y cual es el dia de mayor precipitacion durante los 10 años.-
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PeriodosDeLluviaResponse PeriodosDeLluvia()
        {
            return new PeriodosDeLluviaResponse
            {
                CantidadPeriodosDeLluvia = consultaClimaService.ObtenerCantidadPeriodosDeLluvia(),
                DiaPicoMaximoDeLluvia = consultaClimaService.ObtenerDiaPicoMaximoDeLluvia()
            };
        }

        /// <summary>
        /// Devuelve la cantidad de Periodos de Sequia en los proximos 10 años-.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int PeriodosDeSequia()
        {
            return consultaClimaService.ObtenerCantidadPeriodosDeSequia();
        }

        /// <summary>
        /// Devuelve la cantidad periodos de condiciones optimas de temperatura y presion en los proximos 10 años-
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int PeriodosCondicionesOptimas()
        {
            return consultaClimaService.ObtenerCantidadPeriodosDeCondicionesOptimas();
        }


    }
}