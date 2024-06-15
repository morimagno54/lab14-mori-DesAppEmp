using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab14.Models;

namespace Lab14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents(
            [FromQuery] string firstName = "",
            [FromQuery] string lastName = "",
            [FromQuery] string email = "")
        {
            IQueryable<Student> query = _context.Students;

            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = firstName.ToLower();
                query = query.Where(s => s.FirstName.ToLower().Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = lastName.ToLower();
                query = query.Where(s => s.LastName.ToLower().Contains(lastName));
            }

            if (!string.IsNullOrEmpty(email))
            {
                email = email.ToLower();
                query = query.Where(s => s.Email.ToLower().Contains(email));
            }

            query = query.OrderByDescending(s => s.LastName);

            return query.ToList();
        }
    }
}




