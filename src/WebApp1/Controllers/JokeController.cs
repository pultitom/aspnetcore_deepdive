using System.Threading.Tasks;
using WebApp1.Models;
using WebApp1.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    [Route("/api/jokes")]
    public class JokeController : Controller
   {
       // http://localhost:5000/mvc/api/jokes/chuck
       [HttpGet("chuck")]
       public async Task<RandomJokeModel> GetChuckNorrisJoke() {
           return await MyHttpClient<RandomJokeModel>.GetAsyncResponse("http://api.icndb.com/jokes/random");
       }
   } 
}