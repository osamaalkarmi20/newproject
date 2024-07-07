using Microsoft.EntityFrameworkCore;
using newproject.data;
using newproject.Models.Interface;
using System.Net;

namespace newproject.Models.Service
{
    public class CourseService : ICourse
    {
        private readonly Maindbcontext _context;

        public CourseService(Maindbcontext context)
        {
            _context = context;
        }
        public  async Task<Course> Create(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> Delete(int Id)
        {
            var course = await Get(Id);
            _context.Entry(course).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> Get(int Id)
        {

            var Course = await _context.Courses.FirstOrDefaultAsync(a => a.Id == Id);
            if (Id != null & Course != null)
            {

                return Course;
            }
            else
            {
                throw new Exception("the Id is null or the Id doesnt apply to on the id");

            }
        }

        public async Task<List<Course>> GetAll()
        {
            var course= await _context.Courses.ToListAsync();
            return course;
        }

        public async Task<Course> Update(Course course)
        {

            var cou = await Get(course.Id);
            _context.Entry(cou).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cou;
        }
    }
}
