using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
   {
       private IConfiguration _configuration;

       public HomeController(IConfiguration configuration) {
           _configuration = configuration;
       }
       
       [HttpGet]
       public IActionResult Index() {
           ViewBag.AppName = _configuration["appName"];
           ViewBag.Environment = _configuration["ASPNETCORE_ENVIRONMENT"];
           return View();
       }
   } 
}