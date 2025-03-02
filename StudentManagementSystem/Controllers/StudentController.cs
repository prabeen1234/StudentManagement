using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext studentContext)
        {
            _context = studentContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<StudentModel>> GetStudent()
        {
            var students = _context.Students
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Courses)
                .ToList();

            return Ok(students);
        }
        [HttpPost]
        public ActionResult<StudentModel> Add(StudentModel studentmodel)
        {
            _context.Students.Add(studentmodel);
            _context.SaveChanges();
            return studentmodel;
        }
        [HttpDelete("{id}")]
        public ActionResult<StudentModel> Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound(); 
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok("Deleted Successfully");
        }

    }
}
