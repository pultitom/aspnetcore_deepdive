using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
   public class HomeController : Controller
   {
       private readonly string _appName;

       public HomeController(IConfiguration configuration) {
           _appName = configuration["appName"];
       }
       
       public IActionResult Index() {
           ViewBag.AppName = _appName;
           return View();
       }

       [HttpGet]
       public IActionResult IndexApi() {
           return Ok(new { SomeKey = 1, value = "some value", appName = _appName });
       }
   } 
}