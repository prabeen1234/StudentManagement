using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class CourseModel
    {
        [Key]
        public int Id { get; set; }
        public string CourseName {get;set;}
        public List<StudentCourseModel> StudentCourses { get; set; }

    }
}
