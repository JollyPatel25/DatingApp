using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Entities;
using DatingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.Controllers
{
    [Authorize]
    public class MembersController(AppDbContext context) : BaseApiController
    {
        [AllowAnonymous]
        //"http://localhost:5003/api/members"
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }

        //"http://localhost:5003/api/members/{id}"
        [HttpGet("{id}")]
        public ActionResult<AppUser> Member(String id)
        {
            var member = context.Users.Find(id);
            if (member == null) return NotFound();
            return member;
        }
    }
}
