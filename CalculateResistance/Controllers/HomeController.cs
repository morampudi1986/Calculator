using CalcuateResistance.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculateResistance.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOhmValueCalculator _calculator;
        
        public HomeController(IOhmValueCalculator calculator)
        {
            _calculator = calculator;
        }

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public String Calculate(string model)
        {

            //Color[] selectedColors = JsonConvert.DeserializeObject<Color[]>("[{Name: \"Yellow\"}, {Name: \"Violet\"}, {Name: \"Red\"}, {Name: \"Gold\"}]");
            Color[] selectedColors = JsonConvert.DeserializeObject<Color[]>(Convert.ToString(model));
            int resistance = _calculator.CalculateOhmValue(selectedColors[0].Name, selectedColors[1].Name, selectedColors[2].Name, selectedColors[3].Name);
            return resistance.ToString() + " ohms";

        }
    }
}