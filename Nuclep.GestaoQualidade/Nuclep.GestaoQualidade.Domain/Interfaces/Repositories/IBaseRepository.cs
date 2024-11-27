using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, Tkey> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddListAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        //Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> where);
        //Task<TEntity?> GetByIdAsync(Tkey id);
        //Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where);
        //Task<List<TEntity>> GetAllAtivosAsync(Expression<Func<TEntity, bool>> where);
        Task<bool> VerifyExistsAsync(Expression<Func<TEntity, bool>> where);
    }
}
