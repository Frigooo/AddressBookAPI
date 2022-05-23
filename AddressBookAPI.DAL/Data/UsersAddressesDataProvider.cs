using AddressBookAPI.DAL.Entities;
using AddressBookAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.DAL.Data
{
    public class UsersAddressesDataProvider : IDataProvider<UserAddress>
    {
        public IList<UserAddress> ProvideData()
        {
            return new List<UserAddress>
            {
                new UserAddress
                {
                    Id = 1,
                    UserId = 1,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 2,
                    UserId = 2,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 3,
                    UserId = 3,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 4,
                    UserId = 4,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 5,
                    UserId = 5,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 6,
                    UserId = 6,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 7,
                    UserId = 7,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 8,
                    UserId = 8,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 9,
                    UserId = 9,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                },
                new UserAddress
                {
                    Id = 10,
                    UserId = 10,
                    Country = "Romania",
                    City = "Bucharest",
                    Street = "Vacaresti",
                    PostalCode = "1111"
                }
            };
        }
    }
}
