using AddressBookAPI.BLL.Models;
using AddressBookAPI.BLL.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.BLL.Interfaces
{
    public interface IUserService
    {
        Task<Response<List<UserDto>>> GetUsersAsync(PaginationDto paginationDto, string route);
    }
}
