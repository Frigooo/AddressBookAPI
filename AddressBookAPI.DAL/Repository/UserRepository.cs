using AddressBookAPI.DAL.Entities;
using AddressBookAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.DAL.Repository
{
    public class UserRepository : BasicOperations<User>, IUserRepository
    {
        public UserRepository(IDataProvider<User> dataProvider) : base(dataProvider)
        {
        }

        public async Task<int> CountAsync()
        {
            return await Task.Run(() => _data.Count());
        }
    }
}
