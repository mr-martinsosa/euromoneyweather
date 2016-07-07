using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace euromoneyweather.Models
{
    public class Country
    {
        //[Key, ForeignKey("Weather")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        public string CityName { get; set; }
        
        //[Required]
        public Weather Weather { get; set; }
               
    }
}