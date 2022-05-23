using AddressBookAPI.DAL.Entities;
using AddressBookAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.DAL.Data
{
    public class UsersDataProvider : IDataProvider<User>
    {
        public IList<User> ProvideData() => new List<User>
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
