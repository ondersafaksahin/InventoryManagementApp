using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="C">CreateDTO class to use</typeparam>
    /// <typeparam name="U">UpdateDTO class to use</typeparam>
    /// <typeparam name="L">ListDTO class to use</typeparam>
    /// <typeparam name="T">DTO Type of entity</typeparam>
    /// <typeparam name="B">The base entity</typeparam>
    /// <typeparam name="I">ID type of the entity</typeparam>
    public interface IBaseService<C,U,L,T,B,I>
    {
        Task<I> Create(C createDTO);
        Task Update(U updateDTO);
        Task Delete(I id);
        Task<List<L>> GetDefaults(Expression<Func<B, bool>> expression);
        Task<List<L>> All();
        Task<T> GetById(I id);
        Task<string?> GetNameById(int? Id);

    }
}
