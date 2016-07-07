using euromoneyweather.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using euromoneyweather.DTOs;
using euromoneyweather.Models;

namespace euromoneyweather.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            WeatherInitializer wi = new WeatherInitializer();
            WeatherContext wc = new WeatherContext();
            await wi.manualSeed(wc);
            return RedirectToAction("Index", "Weathers"); //wait for seed to redirect to weathers page
        }
        
    }  

}