using Lewy.Core.Entities;
using Lewy.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LewyApi.Controllers
{
    public class BuggyController: BaseApiContoller
    {
        private readonly LewyContext _context;

        public BuggyController(LewyContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("Auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.AppUsers.Find(-1);
            if (thing == null) return NotFound();

            return Ok(thing);
        }

        [HttpGet("Server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _context.AppUsers.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadrequest()
        {
            return BadRequest("This was not a Good request");
        }

    }
}
