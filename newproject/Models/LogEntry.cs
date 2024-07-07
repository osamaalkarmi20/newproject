namespace newproject.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime CreatedTime { get; set; }
    }

}
