using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using DataPersistence.Contexts;
using System.Linq;

namespace WebApp1.Controllers
{
    [Route("/api/contacts")]
    public class ContactController : Controller
    {
        private MyDbContext _dbContext;

        public ContactController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // http://localhost:5000/mvc/api/contacts/
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._dbContext.Contacts.ToList());
        }

        // http://localhost:5000/mvc/api/contacts/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = this._dbContext.Contacts.FirstOrDefault(e => e.Id == id);

            if (contact == null) {
                return NotFound();
            }

            return Ok(contact);
        }

        // http://localhost:5000/mvc/api/contacts/
        [HttpPost]
        public IActionResult Post([FromBody]MyContact contact)
        {
            this._dbContext.Contacts.Add(contact);
            this._dbContext.SaveChanges();
            return Created("Get", contact);
        }
    }
}