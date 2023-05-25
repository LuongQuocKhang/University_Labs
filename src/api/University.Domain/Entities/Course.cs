using University.Domain.Common;
using University.Domain.Entities;

namespace University.Domain.Course
{
    public class Course : EntityBase
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int NumberOfEnrolled { get; set; }
        public string ImageURL { get; set; }
        public int InstructorId { get; set; }
        public decimal CourseCredit { get; set; }
        public bool IsEnrolled { get; set; }

        //List<Student> Students { get; set; } = new List<Student>();
    }
}
