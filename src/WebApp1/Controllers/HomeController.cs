using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApp1.Controllers
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
   } 
}