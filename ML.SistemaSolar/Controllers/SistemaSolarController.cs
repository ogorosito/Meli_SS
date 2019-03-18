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
        private const string NO_HAY_INFO = "No hay información disponible para el día solicitado.";

        private readonly IConsultaClimaService consultaClimaService;
        private readonly IMapper mapper;

        public SistemaSolarController(IConsultaClimaService consultaClimaService, IMapper mapper)
        {
            this.consultaClimaService = consultaClimaService;
            this.mapper = mapper;
        }


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
                return Ok(NO_HAY_INFO);
            }
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
            return consultaClimaService.ObtenerCantidadPeriodosDeCondicionesOptimas();
        }





    }
}