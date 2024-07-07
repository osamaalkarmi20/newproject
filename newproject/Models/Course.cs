namespace newproject.Models
{
    public class Course
    {public int Id { get; set; }
        
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Enrollment>? Enrollments { get; set; }
    }
}
