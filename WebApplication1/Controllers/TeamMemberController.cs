using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;

namespace WebAPI.Controllers
{

    public class TeamMemberController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamMemberController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamMember>> Get()
        {
            return _context.TeamMembers.Include(x => x.Hobbies).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<TeamMember> Get(int id)
        {
            var teamMember = _context.TeamMembers.Include(x => x.Hobbies).FirstOrDefault(x => x.Id == id);

            if (teamMember == null)
            {
                return NotFound();
            }

            return teamMember;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = teamMember.Id }, teamMember);
        }
    }



}