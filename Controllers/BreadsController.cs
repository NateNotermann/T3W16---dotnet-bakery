using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreadsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BreadsController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Bread> GetBreads()
        {
            // bakeBy property is a list of Baker objects
            // this is how we JOIN
            return _context.Breads.Include(bread => bread.bakedBy);
        }


        [HttpPost]
        public Bread Post(Bread bread)
        {
            // tell post about our new bread object
            _context.Add(bread);
            // save bread object to database
            _context.SaveChanges();

            // respond back with created object 
            return bread;
        }

        [HttpPut("{id}")]
        public Bread Put(int id, Bread bread)
        {
            bread.id = id;
            // telling the db context about our updated bread object
            _context.Update(bread);
        
            _context.SaveChanges();

            // respond back with created bread object

            return bread;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // find the bread by id
            Bread bread = _context.Breads.Find(id);

            _context.Breads.Remove(bread);

            _context.SaveChanges();
        }


    }
}
