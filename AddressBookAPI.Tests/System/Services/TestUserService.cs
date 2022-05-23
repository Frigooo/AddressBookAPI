using AddressBookAPI.BLL.Interfaces;
using AddressBookAPI.BLL.Models;
using AddressBookAPI.BLL.Services;
using AddressBookAPI.DAL.Interfaces;
using AddressBookAPI.Tests.MockData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressBookAPI.Tests.System.Services
{
    public class TestUserService
    {
        [Fact]
        public async Task GetUsersAsync_ValidIdNonExistent_Returns404()
        {
            var userRepository = new Mock<IUserRepository>();
            var uriService = new Mock<IUriService>();

            //userAddressService.Setup(_ => _.GetByUserId(id)).ThrowsAsync(new KeyNotFoundException());

            var service = new UserService(userRepository.Object, uriService.Object);

        }
    }
}
