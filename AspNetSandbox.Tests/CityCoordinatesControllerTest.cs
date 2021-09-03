using AspNetSandbox.Controllers;
using System;
using System.IO;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class CityCoordinatesControllerTest
    {
        [Fact]
        public void GetCityCoordinatesTest()
        {
            //Asume
            string content = "{\"coord\":{\"lon\":139.6917,\"lat\":35.6895},\"weather\":[{\"id\":520,\"main\":\"Rain\",\"description\":\"light intensity shower rain\",\"icon\":\"09d\"}],\"base\":\"stations\",\"main\":{\"temp\":292.15,\"feels_like\":292.56,\"temp_min\":291.37,\"temp_max\":293.13,\"pressure\":1010,\"humidity\":94},\"visibility\":10000,\"wind\":{\"speed\":0.89,\"deg\":351,\"gust\":2.24},\"rain\":{\"1h\":2.73},\"clouds\":{\"all\":75},\"dt\":1630614594,\"sys\":{\"type\":2,\"id\":2038398,\"country\":\"JP\",\"sunrise\":1630613683,\"sunset\":1630660027},\"timezone\":32400,\"id\":1850144,\"name\":\"Tokyo\",\"cod\":200}";
           // string content = LoadJsonFromResource();
            var controller = new CityCoordinatesController();

            // Act
            var output = controller.ConvertCityCoordinates(content);

            // Assert
            var cityCoordinates = ((CityCoordinates)output);
            Assert.Equal(35.68, cityCoordinates.Latitude);
            Assert.Equal(139.69, cityCoordinates.Longitude);
            
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
