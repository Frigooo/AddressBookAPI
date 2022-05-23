using AddressBookAPI.BLL.Interfaces;
using AddressBookAPI.BLL.Wrappers;
using AddressBookAPI.Controllers;
using AddressBookAPI.Tests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace AddressBookAPI.Tests.System.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async Task GetUsersAsync_CorrectPagination_Returns200()
        {
            var userService = new Mock<IUserService>();
            var userAddressService = new Mock<IUserAddressService>();

            var mockPagination = PaginationMockData.PaginationDtoMock();
            string route = "/api/User";
            userService.Setup(_ => _.GetUsersAsync(mockPagination, route)).ReturnsAsync(UserMockData.GetUserDtosResponse());

            var controller = new UserController(userService.Object, userAddressService.Object);

            var result = (OkObjectResult)await controller.GetUsersAsync(mockPagination);

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void PaginationModelValidity_InvalidValue_GivesErrorMessage()
        {
            // act
            var mockPagination = PaginationMockData.BadPaginationDtoMock();
            var validationResults = ValidateModel(mockPagination);

            // assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains(nameof(mockPagination.PageSize)) 
            && v.ErrorMessage != null 
            && v.ErrorMessage.Contains("must be between"));
        }

        [Theory]
        [InlineData(1)]
        public async Task GetUserAddressAsync_ValidId_Returns200(int id)
        {
            var userService = new Mock<IUserService>();
            var userAddressService = new Mock<IUserAddressService>();
            userAddressService.Setup(_ => _.GetByUserId(id)).ReturnsAsync(UserMockData.GetUserAddressDtoResponse());

            var controller = new UserController(userService.Object, userAddressService.Object);

            var result = (OkObjectResult)await controller.GetUserAddressAsync(id);

            result.StatusCode.Should().Be(200);
        }

        //[Theory]
        //[InlineData(-1)]
        //public async Task GetUserAddressAsync_InvalidId_Returns400(int id)
        //{
        //    var userService = new Mock<IUserService>();
        //    var userAddressService = new Mock<IUserAddressService>();

        //    var controller = new UserController(userService.Object, userAddressService.Object);

        //    var result = (ObjectResult)await controller.GetUserAddressAsync(id);

        //    result.StatusCode.Should().Be(400);
        //}

        [Theory]
        [InlineData(100)]
        public async Task GetUserAddressAsync_ValidIdNonExistent_Returns404(int id)
        {
            var context = new DefaultHttpContext();
            var userService = new Mock<IUserService>();
            var userAddressService = new Mock<IUserAddressService>();
            userAddressService.Setup(_ => _.GetByUserId(id)).ThrowsAsync(new KeyNotFoundException());

            var controller = new UserController(userService.Object, userAddressService.Object);
            
            try
            {
                var  result = (ObjectResult)await controller.GetUserAddressAsync(id);

                result.StatusCode.Should().Be(404);
            }
            catch (Exception error)
            {
                var response = GetResponseAfterCheckingExceptionType(error, context);
                response.StatusCode.Should().Be(404);
            }
        }


        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        private HttpResponse GetResponseAfterCheckingExceptionType(Exception error, HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return response;
        }
    }
}
