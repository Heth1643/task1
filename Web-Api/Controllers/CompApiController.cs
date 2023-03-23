using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompApiController : ControllerBase
    {

        private readonly Traineedb17Context _db;

        public CompApiController(Traineedb17Context db)
        {
            _db = db;


        }
        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            var x = _db.Companies.ToList();
            return Ok(x);

        }

        [HttpGet("Emp")] 
        public async Task<IActionResult> GetEmployee()
        {
            var x = _db.Empdetails.ToList();
            return Ok(x);

        }
        [HttpPost]
        public async Task<IActionResult> PostComp(Company com)
        {
            Company c=new Company();
            c.CompName=com.CompName;
            c.ComRef=com.ComRef;
            _db.Companies.Add(c);
            _db.SaveChanges();
            
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Compput(Company com)
        {
            
             Company c=new Company();
            c.CompName=com.CompName;
            c.ComRef=com.ComRef;
            _db.Companies.Update(c);
            _db.SaveChanges();
            
            return Ok();
        }
          [HttpDelete]
        public async Task<IActionResult> Comdelete(int id)
        {
            var x=_db.Companies.Find(id);
            _db.Companies.Remove(x);
                 _db.SaveChanges();
            
            return Ok();
        }

    }
}