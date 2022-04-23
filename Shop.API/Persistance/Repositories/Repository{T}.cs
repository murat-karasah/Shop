using Microsoft.EntityFrameworkCore;
using Shop.API.Core.Interface;
using Shop.API.Persistance.Context;
using System.Linq.Expressions;

namespace Shop.API.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ShopContext shopContext;

        public Repository(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.shopContext.Set<T>().AddAsync(entity);
            await this.shopContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.shopContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return await shopContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetById(object id)
        {
            return await this.shopContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this.shopContext.Set<T>().Remove(entity);
            await this.shopContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.shopContext.Set<T>().Update(entity);
            await this.shopContext.SaveChangesAsync();
        }
    }
}
