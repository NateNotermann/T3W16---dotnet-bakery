using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        // _context is instance of ApplicationContext class
        // we use _context to query our database
        //_context is kind of like "pool.query"
        private readonly ApplicationContext _context;
        // this is our constructor function
        // our ApplicationContext is automagically passed to it as an argument by .NET
        public BakersController(ApplicationContext context)
        {
            _context = context;
        }
        // [ HttpGet] defines this method as our GET
        // this returns an IEnumerable<Baker> object,
        // which is .NET's fancy way of saying a list of the baker objects
        // No SQL query's 
        [HttpGet]
        public IEnumerable<Baker> GetAll()
        {
            // find all record from bakers table
            return _context.Bakers;
        }

        [HttpGet("{id}")]
        public ActionResult<Baker> GetById(int id)
        {
            Baker baker = _context.Bakers.SingleOrDefault(baker => baker.id == id);

            if (baker is null)
            {
                return NotFound();
            }
                return baker;
        }
        [HttpPost]

        public Baker Post(Baker baker)
        {
            _context.Add(baker);
            _context.SaveChanges();
            return baker;
        }
    }
}
