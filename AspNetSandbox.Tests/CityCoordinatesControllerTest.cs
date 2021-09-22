using System;
using System.IO;
using AspNetSandbox.Controllers;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>
    /// Tests CityCoordinatesController.
    /// </summary>
    public class CityCoordinatesControllerTest
    {
        /// <summary>
        /// Gets the city coordinates test.
        /// </summary>
        [Fact]
        public void GetCityCoordinatesTest()
        {
            // Asume
            string content = LoadJsonFromResource();
            var controller = new CityCoordinatesController();

            // Act
            var output = controller.ConvertCityCoordinates(content);

            // Assert
            var cityCoordinates = (CityCoordinates)output;
            Assert.Equal(35.6895, cityCoordinates.Latitude);
            Assert.Equal(139.6917, cityCoordinates.Longitude);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataForCityCoordinates.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
