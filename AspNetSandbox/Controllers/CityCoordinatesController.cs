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
    [ApiController]
    [Route("[controller]")]
    public class CityCoordinatesController : ControllerBase
    {
      
            [HttpGet]
            public IEnumerable<CityCoordinates> Get()
            {
                var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?q=Tokyo&appid=0b0f282945e089f1487e3e8dbccadaf3");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
            
                return ConvertCityCoordinates(response.Content);
            }

            [NonAction]
            public IEnumerable<CityCoordinates> ConvertCityCoordinates(string content)
            {
                var json = JObject.Parse(content);
                // var string = "";

                return Enumerable.Range(1, 5).Select(index =>
                {
                  //  var jsonDailyForecast = json["coord"][0];
                    var cityLongitude = (int)json[0].Value<decimal>("lon");
                    var cityLatitude = (int)json[0].Value<decimal>("lat");

                    return new CityCoordinates
                    {
                        // Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                        Longitude = cityLongitude,
                        Latitude = cityLatitude

                    };
                })
                .ToArray();
            }
        }
    
}
