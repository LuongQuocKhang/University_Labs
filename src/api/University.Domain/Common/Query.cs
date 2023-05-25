namespace University.Domain.Common
{
    public static class CourseQuery
    {
        public static string GetAllAvailableCourse = "SELECT * FROM COURSE WITH(NOLOCK)";

        public static string GetEnrolledCourse = "SELECT * FROM COURSE WITH(NOLOCK)";

        public static string GetCourseByName = @"SELECT * FROM COURSE WITH(NOLOCK)
                                                WHERE CourseName LIKE '%@CourseName%'";
    }
}
