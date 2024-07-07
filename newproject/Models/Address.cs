namespace newproject.Models
{
    public class Address
    {
        public int Id { get; set; }
        
        public int StudentId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public Student Student { get; set; }
    }
}
