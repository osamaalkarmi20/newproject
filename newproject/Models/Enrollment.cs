using System.ComponentModel.DataAnnotations.Schema;

namespace newproject.Models
{
    public class Enrollment
    {
    
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
