using AddressBookAPI.DAL.Data;
using AddressBookAPI.DAL.Entities;
using AddressBookAPI.DAL.Filters;
using AddressBookAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAPI.DAL.Repository
{
    public class BasicOperations<T> : IBasicOperations<T> where T : BaseEntity
    {
        protected IList<T> _data;

        public BasicOperations(IDataProvider<T> dataProvider)
        {
            _data = dataProvider.ProvideData();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _data.Remove(entity));
        }

        public async Task<IList<T>> GetAllAsync(PaginationFilter filter)
        {
            return await Task.Run(() => _data
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToList());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                return _data.FirstOrDefault(x => x.Id == id);
            });
        }

        public async Task InsertAsync(T entity)
        {
            await Task.Run(() => _data.Add(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                var desiredEntity = _data.FirstOrDefault(x => x.Id == entity.Id);
                desiredEntity = entity;
            });
        }
    }
}
