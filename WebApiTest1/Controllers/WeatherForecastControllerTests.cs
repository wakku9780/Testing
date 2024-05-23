using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using WebApplication3.Controllers;

namespace WebApplication3.Tests
{
    [TestClass]
    public class WeatherForecastControllerTests
    {
        private Mock<ILogger<WeatherForecastController>> _loggerMock;
        private WeatherForecastController _controller;

        [TestInitialize]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_loggerMock.Object);
        }

        [TestMethod]
        public void Get_ReturnsWeatherForecasts()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void Get_ReturnsDifferentWeatherForecasts()
        {
            // Act
            var result = _controller.Get().ToList();

            // Assert
            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.AreNotEqual(result[i].Summary, result[i + 1].Summary);
                Assert.AreNotEqual(result[i].Date, result[i + 1].Date);
            }
        }
    }
}
