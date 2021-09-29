using MediatR;
using Xunit;
using Moq;
using How2MediatR.Core.Queries;
using System.Threading;
using How2MediatR.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using How2MediatR.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void GetAsync_ValidData()
        {
            //assert
            var testDate = DateTime.Now;
            var testSummary = "Chilly";
            var testTemperature = 32;

            var testForecast = new WeatherForecast
            { 
                Date = testDate,
                Summary = testSummary,
                TemperatureC = testTemperature
            };

            List<WeatherForecast> list = new List<WeatherForecast>();
            list.Add(testForecast);
            IEnumerable<WeatherForecast> testResponse = list;

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(s => s.Send(It.IsAny<GetForecastByDaysQuery>(), It.IsAny<CancellationToken>()))
                 .Returns(Task.FromResult(testResponse));

            var controller = new WeatherForecastController(mediatorMock.Object);
           
            //act
            var response = controller.GetAsync(It.IsAny<int>(), It.IsAny<string>());

            //assert
            mediatorMock.Verify(
                v => v.Send(It.IsAny<GetForecastByDaysQuery>(), It.IsAny<CancellationToken>()),
                Times.Once());
            Assert.IsType<Task<IEnumerable<WeatherForecast>>>(response);
        }
    }
}
