namespace StudentManagementSystem.Models
{
    public class StudentCourseModel
    {
        public StudentModel Students { get; set; }
        public int StudentId { get; set; }

        public CourseModel Courses { get; set; }
        public int CourseId { get;set; }
    }
}
