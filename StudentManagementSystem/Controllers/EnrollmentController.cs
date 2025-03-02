using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController: ControllerBase    
    {
        private readonly StudentContext _context;

        public EnrollmentController(StudentContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> EnrollStudent(int studentId,int courseId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var course =await  _context.Courses.FindAsync(courseId);

            if ( student == null || course == null )
            {
                return NotFound("Not found");

            }
            var enroll = new StudentCourseModel()
            {
                CourseId = courseId,
                StudentId = studentId
            };

            _context.StudentCourses.Add(enroll);
            await _context.SaveChangesAsync();
            return Ok("Successfully enrolled");

        }
       
        [HttpGet]
        public ActionResult<IEnumerable<StudentCourseModel>> GetEnrolled(int studentId, int courseId)
        {
            var enrolledStudents = _context.StudentCourses
                .Where(sc => sc.StudentId == studentId && sc.CourseId == courseId)
                .Include(sc => sc.Students) 
                .Include(sc => sc.Courses)  
                .Select(sc => new StudentCourseModel
                {
                    StudentId = sc.StudentId,
                    Students = new StudentModel { Name = sc.Students.Name,
                        Age = sc.Students.Age,
                    },
                    Courses = new CourseModel { CourseName = sc.Courses.CourseName,
                    },
                    CourseId = sc.CourseId,

                })
                .ToList();

            if (!enrolledStudents.Any())
            {
                return NotFound("No enrollment found for the given student and course.");
            }

            return Ok(enrolledStudents); 
        }

    }
}
