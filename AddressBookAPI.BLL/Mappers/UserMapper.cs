using AddressBookAPI.BLL.Models;
using AddressBookAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.BLL.Mappers
{
    public static class UserMapper
    {
        public static List<UserDto> ToDto(this List<User> entities)
            => entities.Select(x => x.ToDto()).ToList();

        public static UserDto ToDto(this User entity)
            => new UserDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age
            };
    }
}
