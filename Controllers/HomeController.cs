using System;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApplication
{
   public class HomeController : Controller
   {
       public IActionResult Index() {
           return View();
       }

       [HttpGet]
       public IActionResult IndexApi() {
           return Ok(new { SomeKey = 1, value = "some value" });
       }
   } 
}