using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace euromoneyweather.Models
{
    public class Weather
    {
        //public int WeatherID { get; set; }
        [Key]
        [ForeignKey("aCountry")]        
        public int CountryID { get; set; }
        public float MainTemp{ get; set; }
        public float MaxTemp { get; set; }
        public float MinTemp { get; set; }
        public int Humidity { get; set; }
  
        //[Required]
        public virtual Country aCountry { get; set; }

    }
}