using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using euromoneyweather.DAL;
using euromoneyweather.Models;

namespace euromoneyweather.Controllers
{
    public class WeathersController : Controller
    {
        private WeatherContext db = new WeatherContext();

        // GET: Weathers
        public ActionResult Index(float? searchMainTemp, float? searchMaxTemp, float? searchMinTemp, int? searchHumidity, string searchCity)
        {
            /* pull specific data to throw at search boxes for filter */

            var temp = from t in db.Temperatures/*.Include(i => i.aCountry.CityName)*/ select t;
            //var city = from c in db.Temperatures.Include(c => c.aCountry.CityName) select c;
            if (searchMainTemp != null)
            {
                
                temp = temp.Where(t => t.MainTemp > (searchMainTemp)
                    //|| t.MaxTemp > (searchTemp)
                    //|| t.MinTemp > (searchTemp)
                    //|| t.Humidity > (searchTemp));
                                       );
            }
            if (searchMaxTemp != null)
            {
                
                temp = temp.Where(t => t.MainTemp > (searchMaxTemp)
                                       );
            }
            if (searchMinTemp != null)
            {

                temp = temp.Where(t => t.MinTemp > (searchMinTemp)
                                       );
            }
           
            if (searchHumidity != null)
            {

                temp = temp.Where(t => t.Humidity > (searchHumidity));
                                       
            }
            if (!String.IsNullOrEmpty(searchCity))
            {
                temp = temp.Where(t => t.aCountry.CityName.Contains(searchCity));
            }

            //var temperatures = db.Temperatures.Include(w => w.Country);
            //var temp = db.Temperatures.ToList(); 
            //var temp = db.Countries.ToList();
            return View(temp.ToList());//pulling and displaying from db
        }
    }
}
