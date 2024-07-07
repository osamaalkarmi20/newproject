using Microsoft.EntityFrameworkCore;
using newproject.data;
using newproject.Models.Interface;


namespace newproject.Models.Service
{
    public class EnrollmentService : IEnrollment
    {
 private readonly  Maindbcontext _context;

        public EnrollmentService(Maindbcontext context) 
        {
           _context = context;
        }
        public  async Task<Enrollment> Create(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Enrollment> Get(int Id)
        {
            var maindbcontext = await _context.Enrollments.Include(e => e.Course).Include(e => e.Student).FirstOrDefaultAsync(e=> Id==e.StudentId);
            return maindbcontext;
        }

        public async Task<List<Enrollment>> GetAll()
        {
            var maindbcontext = await _context.Enrollments.Include(e => e.Course).Include(e => e.Student).ToListAsync();
            return maindbcontext;
        }

        public Task<Enrollment> Update(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }
    }
}
