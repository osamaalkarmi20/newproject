using Microsoft.EntityFrameworkCore;
using newproject.data;
using newproject.Models.Interface;
using System.Xml.Schema;

namespace newproject.Models.Service
{
    public class StudentService : IStudent
    { private readonly Maindbcontext _context;
        public StudentService(Maindbcontext context)
        {
          _context = context;
        }
        public async Task<Student> Create(Student student)
        {
      await _context.Students.AddAsync(student);
      await     _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Delete(int Id)
        {
            var stud = await Get(Id);
            _context.Entry(stud).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return stud;
        }

        public async Task<Student> Get(int Id)
        {//.Include(s=>s.Enrollments).ThenInclude(s=>s.Course)
            var stud = await _context.Students.Include(s=> s.Address).Select(var a = new List<Enrollment> 
                ).FirstOrDefaultAsync(a => a.Id == Id);
            if (Id != null & stud != null)
            {

                return stud;
            }
            else
            {
                throw new Exception("the Id is null or the Id doesnt apply to on the id");

            }


        }

        public async Task<List<Student>> GetAll()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> Update(Student student)
        {

            var stud = await Get(student.Id);
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return stud;
        }
    }
}
