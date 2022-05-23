using AddressBookAPI.BLL.Models;
using AddressBookAPI.BLL.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.BLL.Interfaces
{
    public interface IUserAddressService
    {
        Task<Response<UserAddressDto?>> GetByUserId(int userId);
    }
}
