using AddressBookAPI.BLL.Interfaces;
using AddressBookAPI.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IUserAddressService _userAddressService;

        public UserController(IUserService userService,
            IUserAddressService userAddressService)
        {
            _userService = userService;
            _userAddressService = userAddressService;   
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync([FromQuery] PaginationDto payload)
        {
            var route = "/api/User";

            return Ok(await _userService.GetUsersAsync(payload, route));
        }

        [HttpGet("{id}/address")]
        public async Task<IActionResult> GetUserAddressAsync([FromRoute] int id)
        {
            return Ok(await _userAddressService.GetByUserId(id));
        }

    }
}
