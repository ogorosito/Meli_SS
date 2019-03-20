using ML.SistemaSolar.Controllers;
using ML.SistemaSolar.Services;
using System;
using Xunit;

namespace ML.SistemaSolar.Tests
{
    public class JobControllerTest
    {
        private readonly JobController controller;
        private readonly IPrediccionClimaService prediccionClimaService;

        public JobControllerTest()
        {
            prediccionClimaService = new PrediccionClimaServiceFake();
            controller = new JobController(prediccionClimaService);
        }

        [Fact]
        public void Execute_ResultOk()
        {
            var result = controller.Execute();
            Assert.True(result.Ok);
        }
    }
}
