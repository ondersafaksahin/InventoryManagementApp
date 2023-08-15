using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.IRepositories
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);
        Task<T> GetById(Expression<Func<T, bool>> expression);

        Task<bool> Any(Expression<Func<T, bool>> expression);

        Task<List<T>> GetAll();
    }
}
