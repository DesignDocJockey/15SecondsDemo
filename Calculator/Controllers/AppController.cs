using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;
using Newtonsoft.Json;

namespace Calculator.Controllers
{
    public class AppController : Controller
    {
        private string PostURI => "api/Calculate";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Index")]
        public async Task<IActionResult> Index(CalculationInputs numberInput)
        {
            using (var client = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(numberInput);
                var baseURI = @"http://localhost:60110/";
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Clear();
              
                var data = new StringContent( myContent, Encoding.UTF8, "application/json");
                var response =  await client.PostAsync(PostURI, data);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.UserMessage = $"Your Result is: {response.Content.ReadAsStringAsync().Result}";
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}