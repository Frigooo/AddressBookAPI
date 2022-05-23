using AddressBookAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.DAL.Interfaces
{
    public interface IUserAddressRepository : IBasicOperations<UserAddress>
    {
        Task<UserAddress> GetByUserIdAsync(int id);
    }
}
