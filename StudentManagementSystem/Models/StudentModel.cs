using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<StudentCourseModel> StudentCourses { get; set; }
    }
}
