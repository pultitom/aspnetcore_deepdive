using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp1.Models;
using WebApp1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Domain.Models;

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

       [HttpGet]
       public IActionResult IndexApi() {
           var contact = new MyContact();
           contact.Name = _appName;
           contact.Email = "mytestmail@mytestmail.com";
           contact.Phone = "112";

           return Ok(contact);
       }

       [HttpGet("[controller]/joke")]
       public async Task<RandomJokeModel> GetJoke() {
           return await MyHttpClient<RandomJokeModel>.GetAsyncResponse("http://api.icndb.com/jokes/random");
       }
   } 
}