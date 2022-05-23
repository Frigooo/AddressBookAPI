using AddressBookAPI.BLL.Models;
using AddressBookAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.BLL.Mappers
{
    public static class UserAddressMapper
    {
        public static UserAddressDto? ToDto(this UserAddress entity)
            =>
            entity != null
            ? new UserAddressDto
            {
                Id = entity.Id,
                Country = entity.Country,
                City = entity.City,
                Street = entity.Street,
                PostalCode = entity.PostalCode
            }
            : null;
    }
}
