using System.ComponentModel.DataAnnotations;

namespace AddressBookAPI.BLL.Models
{
    public class PaginationDto
    {
        public int PageNumber { get; set; }

        [Range(1,10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PageSize { get; set; }
    }
}
