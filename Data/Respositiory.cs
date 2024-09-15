
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogAPI.Data
{
    public class Respositiory<T> : IRespositiory<T> where T : class
    {
        public readonly ApplicationDbContext db;

        public Respositiory(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.Set<T>().FindAsync(id);
            db.Set<T>().Remove(data);
        }

        public async Task<List<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllFeatured(Expression<Func<T, bool>> filter)
        {
            return await db.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task Savechangesasync()
        {
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            db.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
