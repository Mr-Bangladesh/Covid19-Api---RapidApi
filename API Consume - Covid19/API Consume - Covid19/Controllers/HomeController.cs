using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_Consume___Covid19.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace API_Consume___Covid19.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CountryModel model)
        {
            string countryName = model.Name;
            //string date = DateTime.Today.ToString("yyyy-MM-dd");
            string date = model.Date.ToString("yyyy-MM-dd");

            string server = "https://covid-19-data.p.rapidapi.com/report/country/name?name=" + countryName + "&date=" + date;

            var client = new RestClient(server);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "covid-19-data.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "101962def0msh0f5400fc24cbac3p1b15c1jsn4978f762efbc");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            List<CovidDataModel> covidDataModel = new List<CovidDataModel>();

            try
            {
                covidDataModel = JsonConvert.DeserializeObject<List<CovidDataModel>>(response.Content);

                ViewBag.covidDataModel = covidDataModel;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }

            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
