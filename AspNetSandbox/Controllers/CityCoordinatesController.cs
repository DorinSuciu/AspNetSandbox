using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    /// <summary>
    /// Controller that allows us to get city coordinates.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CityCoordinatesController : ControllerBase
    {
        /// <summary>
        /// Gets the specified city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns>Tokyo coordinates.</returns>
        [HttpGet]
        [Route("/citycoordinates/{city}")]
        public CityCoordinates Get(string city)
            {
                var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=0b0f282945e089f1487e3e8dbccadaf3");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return ConvertCityCoordinates(response.Content);
            }

        /// <summary>Converts the city coordinates.</summary>
        /// <param name="content">The content.</param>
        /// <returns>CityCoordinates object.</returns>
        [NonAction]
        public CityCoordinates ConvertCityCoordinates(string content)
            {
                var json = JObject.Parse(content);

                var cityLongitude = json["coord"].Value<double>("lon");
                var cityLatitude = json["coord"].Value<double>("lat");
                return new CityCoordinates
                    {
                        Longitude = Math.Round(cityLongitude, 4),
                        Latitude = Math.Round(cityLatitude, 4),
                    };
            }
        }
}
