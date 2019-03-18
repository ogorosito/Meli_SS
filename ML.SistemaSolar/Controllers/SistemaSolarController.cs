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
    public class SistemaSolarController : ControllerBase
    {
        private readonly IConsultaClimaService consultaClimaService;

        public SistemaSolarController(IConsultaClimaService consultaClimaService)
        {
            this.consultaClimaService = consultaClimaService;
        }


        [HttpGet]
        public ClimaResponse Clima([FromQuery]int dia)
        {
            return new ClimaResponse
            {
                Dia = dia,
                Clima = "No especificado"
            };
        }

        [HttpGet]
        public PeriodosDeLluviaResponse PeriodosDeLluvia()
        {
            return new PeriodosDeLluviaResponse
            {
                CantidadPeriodosDeLluvia = consultaClimaService.ObtenerCantidadPeriodosDeLluvia(),
                DiaPicoMaximoDeLluvia = consultaClimaService.ObtenerDiaPicoMaximoDeLluvia()
            };
        }

        [HttpGet]
        public int PeriodosDeSequia()
        {
            return consultaClimaService.ObtenerCantidadPeriodosDeSequia();
        }

        [HttpGet]
        public int PeriodosCondicionesOptimas()
        {
            return 0;
        }





    }
}