using System;
using System.IO;
using AspNetSandbox.Controllers;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>
    /// Tests WeatherForecastController.
    /// </summary>
    public class WeatherForecastControllerTest
    {
        /// <summary>
        /// Converts the response to weather forecast test.
        /// </summary>
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Asume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("Rain", weatherForecastForTomorrow.Summary);
            Assert.Equal(20, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 3), weatherForecastForTomorrow.Date);
        }

        /// <summary>
        /// Converts the response to weather forecast after tomorrow test.
        /// </summary>
        [Fact]
        public void ConvertResponseToWeatherForecastAfterTomorrowTest()
        {
            // Asume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastAfterTomorrow = ((WeatherForecast[])output)[1];
            Assert.Equal("Rain", weatherForecastAfterTomorrow.Summary);
            Assert.Equal(22, weatherForecastAfterTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 4), weatherForecastAfterTomorrow.Date);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenWeatherAPI1.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
