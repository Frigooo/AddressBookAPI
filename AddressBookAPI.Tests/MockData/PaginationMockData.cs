using AddressBookAPI.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.Tests.MockData
{
    public class PaginationMockData
    {
        public static PaginationDto PaginationDtoMock()
            => new PaginationDto { PageNumber = 1, PageSize = 1 };

        public static PaginationDto BadPaginationDtoMock()
            => new PaginationDto { PageNumber = 1, PageSize = 11 };

        public static PaginationDto AllDataPaginationDtoMock()
            => new PaginationDto { PageNumber = 1, PageSize = int.MaxValue };

        public static PaginationDto NoDataPaginationDtoMock()
            => new PaginationDto { PageNumber = 1, PageSize = 0 };
    }
}
