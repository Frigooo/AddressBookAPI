using AddressBookAPI.DAL.Entities;
using AddressBookAPI.DAL.Filters;
using AddressBookAPI.DAL.Interfaces;
using AddressBookAPI.DAL.Repository;
using AddressBookAPI.Tests.MockData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AddressBookAPI.Tests.System.Repositories
{
    public class TestUserRepository
    {
        [Fact]
        public async Task GetAllAsync_ValidPagination_CorrectList()
        {
            var userDataProvider = new Mock<IDataProvider<User>>();
            var paginationDtoMock = PaginationMockData.PaginationDtoMock();
            var pagination = new PaginationFilter(paginationDtoMock.PageNumber, paginationDtoMock.PageSize);
            userDataProvider.Setup(_ => _.ProvideData()).Returns(UserMockData.AllUsersMock());

            var repository = new UserRepository(userDataProvider.Object);

            var result = await repository.GetAllAsync(pagination) as List<User>;

            Assert.Equal(pagination.PageSize, result?.Count);
            Assert.Equal(result[0]?.Id, UserMockData.AllUsersMock()[0].Id);
        }

        [Fact]
        public async Task GetAllAsync_ValidPagination_EntireCorrectList()
        {
            var userDataProvider = new Mock<IDataProvider<User>>();
            var paginationDtoMock = PaginationMockData.AllDataPaginationDtoMock();
            var pagination = new PaginationFilter(paginationDtoMock.PageNumber, paginationDtoMock.PageSize);
            userDataProvider.Setup(_ => _.ProvideData()).Returns(UserMockData.AllUsersMock());

            var repository = new UserRepository(userDataProvider.Object);

            var result = await repository.GetAllAsync(pagination) as List<User>;

            Assert.Equal(result.Count, UserMockData.AllUsersMock().Count);
        }

        [Fact]
        public async Task GetAllAsync_ValidPagination_NoData()
        {
            var userDataProvider = new Mock<IDataProvider<User>>();
            var paginationDtoMock = PaginationMockData.NoDataPaginationDtoMock();
            var pagination = new PaginationFilter(paginationDtoMock.PageNumber, paginationDtoMock.PageSize);
            userDataProvider.Setup(_ => _.ProvideData()).Returns(UserMockData.AllUsersMock());

            var repository = new UserRepository(userDataProvider.Object);

            var result = await repository.GetAllAsync(pagination) as List<User>;

            Assert.Empty(result);
        }
    }
}
