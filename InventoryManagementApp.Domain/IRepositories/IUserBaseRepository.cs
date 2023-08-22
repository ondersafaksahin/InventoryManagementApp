using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.IRepositories
{
    public interface IUserBaseRepository<T> where T : IUser
    {
        Task Update(T item);
        Task Delete(T item);
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);
        Task<T> GetById(Expression<Func<T, bool>> expression);

        Task<bool> Any(Expression<Func<T, bool>> expression);

        Task<List<T>> GetAll();
        Task<string> GeneratePassword();
    }
}
