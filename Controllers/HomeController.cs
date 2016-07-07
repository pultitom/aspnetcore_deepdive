using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApplication.Models;
using ConsoleApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication.Controllers
{
   public class HomeController : Controller
   {
       private readonly string _appName;

       public HomeController(IConfiguration configuration) {
           _appName = configuration["appName"];
       }
       
       [HttpGet]
       public IActionResult Index() {
           ViewBag.AppName = _appName;
           return View();
       }

       [HttpGet]
       public IActionResult IndexApi() {
           return Ok(new { SomeKey = 1, value = "some value", appName = _appName });
       }

       [HttpGet("[controller]/joke")]
       public async Task<RandomJokeModel> GetJoke() {
           return await MyHttpClient<RandomJokeModel>.GetAsyncResponse("http://api.icndb.com/jokes/random");
       }
   } 
}