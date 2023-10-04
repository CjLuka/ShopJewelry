using Application.Contracts.Persistance;
using Persistance.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ShopDbContext _shopDbContext;

        public AsyncRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _shopDbContext.Set<T>().AddAsync(entity);
            await _shopDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>?> GetAll()
        {
            return await _shopDbContext.Set<T>()
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _shopDbContext.Set<T>()
                .FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _shopDbContext.Set<T>()
                .FindAsync(id);
        }
    }
}
