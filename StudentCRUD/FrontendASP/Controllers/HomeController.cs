using FrontendASP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace FrontendASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly string baseUrl = "https://localhost:7290/api/Students";
        private readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var response = client.GetAsync(baseUrl).Result;

            if(response.IsSuccessStatusCode)
            {
                List<Student> students = new List<Student>();

                var jsonData = response.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<Student>>(jsonData);

                return View(students);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var s1 = new { student.studentName, student.studentGender, student.studentAge,
                student.studentBatchCode, student.studentPhone };
            
            string jsonData = JsonConvert.SerializeObject(s1);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = client.PostAsync(baseUrl, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["studentadded"] = "Student Inserted";
                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}