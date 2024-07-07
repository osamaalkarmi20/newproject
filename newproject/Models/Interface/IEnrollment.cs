
namespace newproject.Models.Interface
{
    public interface IEnrollment
    {
        public Task<List<Enrollment>> GetAll();
        public Task<Enrollment> Create(Enrollment enrollment);
        public Task<Enrollment> Update(Enrollment enrollment);
        public Task<Enrollment> Delete(int Id);
        public Task<Enrollment> Get(int Id);
    }
}
