using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;

namespace WebApplication1.Controllers
{
    public class CollegeProgramController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CollegeProgramController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamMember>> Get(string collegeProgram)
        {
            var teamMembers = _context.TeamMembers.Include(x => x.Hobbies).Where(x => x.CollegeProgram == collegeProgram).ToList();

            if (teamMembers.Count == 0)
            {
                return NotFound();
            }

            return teamMembers;
        }
    }
}
