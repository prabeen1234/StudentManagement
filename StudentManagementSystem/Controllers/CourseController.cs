using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController:ControllerBase
    {
        private readonly StudentContext _context;

        public CourseController(StudentContext studentContext)
        {
            _context = studentContext;
        }

        [HttpPost]
        public ActionResult<CourseModel> Add(CourseModel  model)
        {
            _context.Courses.Add(model);
            _context.SaveChanges();
            return Ok("Saved Sucessfully");
                
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseModel>> Get(CourseModel model)
        {
            return _context.Courses
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Students)
                .ToList();
        }
    }
}
