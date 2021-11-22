using Lewy.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LewyApi.Controllers
{
    public class UsersController : BaseApiContoller
    {
        private readonly LewyContext _context;

        public UsersController(LewyContext context)
        {
            _context = context;
        }
         
        [HttpGet("GetUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsers()
        { 

           var users = _context.AppUsers.ToList();

            return Ok(users);
            
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {

            var user = _context.AppUsers.FirstOrDefault(x => x.Id == id);

            return Ok(user);

        }

    }
}
