namespace newproject.Models.Interface
{
    public interface ICourse
    {
        public Task<List<Course>> GetAll();
        public Task<Course> Create(Course course);
        public Task<Course> Update(Course course);
        public Task<Course> Delete(int Id);
        public Task<Course> Get(int Id);
    }
}
