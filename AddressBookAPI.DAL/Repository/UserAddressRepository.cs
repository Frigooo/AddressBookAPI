using AddressBookAPI.DAL.Entities;
using AddressBookAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.DAL.Repository
{
    public class UserAddressRepository : BasicOperations<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(IDataProvider<UserAddress> dataProvider) : base(dataProvider) 
        {
        }

        public async Task<UserAddress> GetByUserIdAsync(int id)
        {
            return await Task.Run(() => _data.FirstOrDefault(x => x.UserId == id));
        }
    }
}
