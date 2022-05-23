using AddressBookAPI.DAL.Entities;
using AddressBookAPI.DAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.DAL.Interfaces
{
    public interface IBasicOperations<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync(PaginationFilter filter);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
    }
}
