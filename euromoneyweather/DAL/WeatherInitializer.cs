using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using euromoneyweather.Models;
using System.Threading.Tasks;
using System.Text;
using euromoneyweather.DTOs;
using System.Data.SqlClient;


namespace euromoneyweather.DAL
{
    public class WeatherInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WeatherContext> //has method seed, we changed it, it gets confused because of webcall to populate
    {
        /* mass api call for cities */ 
        private const string URL = "http://api.openweathermap.org/data/2.5/group?id=2267057, 658226, 6455259, 2643743, 786714, 588409, 456172, 3183875, 3042030, 3186886, 2759794, 524901, 703448, 2993458, 323786, 6691831, 625144, 146268, 6359304, 2761369, 3067696, 2950159, 6692263, 2673730, 6453366, 683506, 3169070, 1526273, 2618425, 2964574, 2802359, 2800866, 7285212, 756135, 3054643, 3060972, 727011, 616051, 3196359, 3193044, 618426, 593116, 2960316, 785842, 2562305, 587084, 3041563, 3191281, 611717, 264371, 3168070&units=metric&APPID=b00df8320d7abd81c15776e43bd17af1&units=metric";
        
        public async Task<CountryWrapper> getWeather()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); //grab data as json and fixing incorrect header that returned as utf8
                var awaitResponse = await response.Content.ReadAsStringAsync(); //read the json response as a string
                var wrapper = JsonConvert.DeserializeObject<CountryWrapper>(awaitResponse); //parse it into readable object
                return wrapper;
            }
            return null;
        }

        public List<Country> getCities(CountryWrapper wrapper)
        {
            List<Country> locations = new List<Country>();
            foreach (var city in wrapper.list)
            {

                locations.Add(
                    new Country()
                    {
                        Id = city.id,
                        CityName = city.name
                    }
                    );
            }
            return locations;
        }

        public List<Weather> getTemperature(CountryWrapper wrapper)
        {
            List<Weather> temperatures = new List<Weather>();
            var r = new Random();
            foreach (var city in wrapper.list)
            {
                temperatures.Add(
                    new Weather()
                    {
                        //WeatherID = r.Next(),
                        CountryID = city.id,
                        MainTemp = city.main.temp,
                        MaxTemp = city.main.temp_max,
                        MinTemp = city.main.temp_min,
                        Humidity = city.main.humidity
                    }
                    );
            }
            return temperatures;
        }

        /*protected override async Task<CountryWrapper> Seed(WeatherContext context)
        {
            var wrapper = await getWeather();
            var cities = getCities(wrapper);
            var temperature = getTemperature(wrapper);
            cities.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();
            temperature.ForEach(t => context.Temperatures.Add(t));
            context.SaveChanges();
            
            return wrapper;
        }
         debug function, in debug mode calls seed. 
         entity framework does not know how to call properly because of async 
         */
        
        public async Task<CountryWrapper> manualSeed(WeatherContext context) //created manual seed to simulate entity frameworks' seed.
        {
            //SqlConnection.ClearAllPools();
            context.Database.Delete(); //had to refresh database since it wouldn't clear automatically
            var wrapper = await getWeather();
            var cities = getCities(wrapper);
            var temperature = getTemperature(wrapper);
            cities.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();
            temperature.ForEach(t => context.Temperatures.Add(t));
            context.SaveChanges();

            return wrapper;
        }
    }
}