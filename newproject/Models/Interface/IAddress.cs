using Microsoft.AspNetCore.Mvc;

namespace newproject.Models.Interface
{
    public interface IAddress
    {
        public Task<List<Address>> GetAll();
        public Task<Address> Create(Address address);
        public Task<Address> Update(Address address);
        public Task<Address> Delete(int Id);
        public Task<Address> Get(int Id);
   
    }
}
