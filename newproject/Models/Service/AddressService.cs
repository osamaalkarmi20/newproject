using Microsoft.EntityFrameworkCore;
using newproject.data;
using newproject.Models.Interface;
using NuGet.Versioning;
using SQLitePCL;

namespace newproject.Models.Service
{
    public class AddressService : IAddress
    {
        private readonly Maindbcontext _context;

        public AddressService(Maindbcontext context)
        {
            _context = context;
        }

        public async Task<Address> Create(Address address)
        {
          
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> Delete(int Id)
        {
           var Address = await Get(Id);
             _context.Entry(Address).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
           return Address;
        }

        public async Task<Address> Get(int Id)
        {
            var Address = await _context.Addresses.Include(s=>s.Student).FirstOrDefaultAsync(a=>a.Id==Id);
            if (Id != null & Address != null)
            {

                return Address;
            }
            else {
                throw new Exception("the Id is null or the Id doesnt apply to on the id");
            
            }


        }

        public async Task<List<Address>> GetAll()
        {
            var Addresses = await _context.Addresses.Include(s => s.Student).ToListAsync();
            return Addresses;
        }

        public async Task<Address> Update(Address address)
        {

            var Address = await Get(address.Id);
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return address;
        }
    }
}
