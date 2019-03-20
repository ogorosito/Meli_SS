using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ML.SistemaSolar.Controllers;
using ML.SistemaSolar.DTOs;
using ML.SistemaSolar.Profiles;
using ML.SistemaSolar.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ML.SistemaSolar.Tests
{
    public class SistemaSolarControllerTest
    {
        private readonly SistemaSolarController controller;
        private readonly IConsultaClimaService consultaClimaService;
        private readonly IMapper mapper;

        public SistemaSolarControllerTest()
        {
            consultaClimaService = new ConsultaClimaServiceFake();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CondicionClimaticaProfile());
            });

            mapper = mockMapper.CreateMapper();
            controller = new SistemaSolarController(consultaClimaService, mapper);
        }


        [Fact]
        public void Clima_Return_ClimaResponse()
        {
            var result = controller.Clima(1);
            Assert.IsType<OkObjectResult>(result);
        }

        //TODO --> Agregar mas pruebas unitarias.


    }
}
