using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly String url = "https://catfact.ninja/fact";
        private HttpClient client = new HttpClient();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                CatFact fact = new CatFact();

                string result = response.Content.ReadAsStringAsync().Result;
                fact = JsonConvert.DeserializeObject<CatFact>(result);

                if (fact != null) 
                {
                    return View(fact);

                }
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