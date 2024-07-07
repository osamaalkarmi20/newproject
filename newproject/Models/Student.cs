namespace newproject.Models
{
    public class Student
    {public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
    public DateTime CreatedDate { get; set; }
        public Address? Address { get; set; }
        public List<Enrollment>? Enrollments  { get; set; }
    }
}
