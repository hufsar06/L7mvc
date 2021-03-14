namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    //tinfo200:[2021-02-22-hufsar06-dykstra1] - This class creates an enrollment object - a student has an "enrollment" into a course
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
    }
}