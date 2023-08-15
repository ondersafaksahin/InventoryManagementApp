﻿using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using InventoryManagementApp.Domain.IRepositories;
using InventoryManagementApp.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly InventoryDbContext _dbContext;
        protected DbSet<T> _table;


        public BaseRepository(InventoryDbContext DbContext)
        {
            _dbContext = DbContext;
            _table = _dbContext.Set<T>();
        }


        public async Task Add(T item)
        {
            await _table.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task Delete(T item)
        {
            item.Status = Status.Deleted;//Oluşturduğun entitynin status propertysinin değerini deleted yap
            await Update(item);
        }

        public async Task<List<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).FirstAsync();
        }

        public async Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task Update(T item)
        {
            _dbContext.Entry<T>(item).State = EntityState.Modified;//Güncelleme Yap
            await _dbContext.SaveChangesAsync();
        }
    }
}