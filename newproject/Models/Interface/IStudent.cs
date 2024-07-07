namespace newproject.Models.Interface
{
    public interface IStudent
    {
        public Task<List<Student>> GetAll();
        public Task<Student> Create(Student student);
        public Task<Student> Update(Student student);
        public Task<Student> Delete(int Id);
        public Task<Student> Get(int Id);
    }
}
