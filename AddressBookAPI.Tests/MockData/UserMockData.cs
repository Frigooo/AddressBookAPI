using AddressBookAPI.BLL.Models;
using AddressBookAPI.BLL.Wrappers;
using AddressBookAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.Tests.MockData
{
    public class UserMockData
    {
        public static PagedResponse<List<UserDto>> GetUserDtosResponse()
        {
            return new PagedResponse<List<UserDto>>(
                new List<UserDto>
                {
                    new UserDto
                    {
                        Id = 1,
                        FirstName = "Lucian",
                        LastName = "Frigioiu",
                        Age = 231
                    }
                }, 1, 1);
        }

        public static Response<UserAddressDto> GetUserAddressDtoResponse()
        {
            return new Response<UserAddressDto>(new UserAddressDto { Id  = 1, UserId = 1, Country = "Romania", City = "Bucharest", PostalCode = "11111", Street = "Camil Ressu"});
        }

        public static List<User> AllUsersMock()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Mihai",
                    LastName = "Popa",
                    Age = 18
                },
                new User
                {
                    Id = 2,
                    FirstName = "Andreea",
                    LastName = "Popa",
                    Age = 18
                },
                new User
                {
                    Id = 3,
                    FirstName = "Alexandru",
                    LastName = "Munteanu",
                    Age = 18
                },
                new User
                {
                    Id = 4,
                    FirstName = "Vasile",
                    LastName = "Ion",
                    Age = 18
                },
                new User
                {
                    Id = 5,
                    FirstName = "Andrei",
                    LastName = "Ionescu",
                    Age = 18
                },
                new User
                {
                    Id = 6,
                    FirstName = "Ioana",
                    LastName = "Ionescu",
                    Age = 18
                },
                new User
                {
                    Id = 7,
                    FirstName = "George",
                    LastName = "Georgescu",
                    Age = 18
                },
                new User
                {
                    Id = 8,
                    FirstName = "Mihai",
                    LastName = "Lucian",
                    Age = 18
                },
                new User
                {
                    Id = 9,
                    FirstName = "Albert",
                    LastName = "Gheorghe",
                    Age = 18
                },
                new User
                {
                    Id = 10,
                    FirstName = "Elena",
                    LastName = "Popa",
                    Age = 18
                },
            };
        }
    }
}
