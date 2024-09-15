using System.Linq.Expressions;

namespace BlogAPI.Data
{
    public interface IRespositiory<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<List<T>> GetAllFeatured(Expression<Func<T,bool>> filter);
        Task<T> GetById(int id);

        Task AddAsync (T entity);
        Task UpdateAsync (T entity);
        Task DeleteAsync (int id);
       
        Task Savechangesasync ();
    }
}
