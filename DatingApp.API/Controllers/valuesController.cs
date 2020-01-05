using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        // GET api/values
        [HttpGet]
        // IActionResult is for Http requests
        // Asnyc request are great to use because it will not block the code and allow other users to send a reuest
        // for async methos Task is the key word
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.values.ToListAsync();
            return Ok(values);
        }
            

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
           var value =await _context.values.FirstOrDefaultAsync(x => x.Id == id);
           return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}