using Lewy.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LewyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly LewyContext _context;

        public HomeController(LewyContext context)
        {
            _context = context;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {

           var users = _context.AppUsers.ToList();

            return Ok(users);
            
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {

            var user = _context.AppUsers.FirstOrDefault(x => x.Id == id);

            return Ok(user);

        }

    }
}
