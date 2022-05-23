using AddressBookAPI.BLL.Helpers;
using AddressBookAPI.BLL.Interfaces;
using AddressBookAPI.BLL.Mappers;
using AddressBookAPI.BLL.Models;
using AddressBookAPI.BLL.Wrappers;
using AddressBookAPI.DAL.Filters;
using AddressBookAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.BLL.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        readonly IUriService _uriService;

        public UserService(IUserRepository userRepository,
            IUriService uriService)
        {
            _userRepository = userRepository;
            _uriService = uriService;
        }

        public async Task<Response<List<UserDto>>> GetUsersAsync(PaginationDto paginationDto, string route)
        {
            var pageFilter = new PaginationFilter(paginationDto.PageNumber, paginationDto.PageSize);
            var pagedData = await _userRepository.GetAllAsync(pageFilter);
            var dtos = pagedData.ToList().ToDto();
            var totalCount = await _userRepository.CountAsync();

            return PaginationHelper.CreatePagedReponse(dtos, pageFilter, totalCount, _uriService, route);
        }
    }
}
