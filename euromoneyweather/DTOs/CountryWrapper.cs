using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace euromoneyweather.DTOs
{
    public class City
    {
        public String name { get; set; }
        public int id { get; set; }
        public Temperature main { get; set; }
    }

    public class CountryWrapper
    {
        public int cnt { get; set; }
        public List<City> list { get; set; }
    }

    public class CountryWeather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
    }

    public class Temperature
    {
        public float temp { get; set; }
        public int humidity { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
    }
}
//json data as object