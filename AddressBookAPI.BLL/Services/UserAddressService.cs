using AddressBookAPI.BLL.Interfaces;
using AddressBookAPI.BLL.Mappers;
using AddressBookAPI.BLL.Models;
using AddressBookAPI.BLL.Wrappers;
using AddressBookAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.BLL.Services
{
    public class UserAddressService : IUserAddressService
    {
        readonly IUserAddressRepository _userAddressRepository;

        public UserAddressService(IUserAddressRepository userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
        }

        public async Task<Response<UserAddressDto?>> GetByUserId(int userId)
        {
            var userAddress = await _userAddressRepository.GetByUserIdAsync(userId);
            if (userAddress == null)
                throw new KeyNotFoundException();

            return new Response<UserAddressDto?>(userAddress.ToDto());
        }
    }
}
