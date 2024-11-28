using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.SqlServer.Contexts;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DataContext _dataContext;

        protected BaseRepository(DataContext context)
        {
            _dataContext = context;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            try
            {
                await _dataContext.AddAsync(entity);
                await _dataContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task AddListAsync(List<TEntity> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    await _dataContext.AddAsync(entity);
                }
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var trackedEntity = _dataContext.Set<TEntity>().Local.FirstOrDefault();
            if (trackedEntity != null)
            {
                _dataContext.Entry(trackedEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _dataContext.Update(entity);
            }
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            try
            {
                var trackedEntity = await _dataContext.Set<TEntity>().FindAsync(_dataContext.Entry(entity).Property("Id").CurrentValue);
                if (trackedEntity != null)
                {
                    _dataContext.Remove(trackedEntity);
                }
                else
                {
                    _dataContext.Remove(entity);
                }
                await _dataContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public virtual async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> where)
        //{
        //    return await _dataContext.Set<TEntity>().FirstOrDefaultAsync(where);
        //}
        //public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        //{
        //    return await _dataContext.Set<TEntity>().FindAsync(id);
        //}

        //public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        //{
        //    try
        //    {
        //        return await _dataContext.Set<TEntity>().Where(where).ToListAsync();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public virtual async Task<List<TEntity>> GetAllAtivosAsync(Expression<Func<TEntity, bool>> where)
        //{
        //    return await _dataContext.Set<TEntity>().Where(where).ToListAsync();
        //}

        public virtual async Task<bool> VerifyExistsAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dataContext.Set<TEntity>().AnyAsync(where);
        }



        public virtual void Dispose()
        {
            _dataContext.Dispose();
        }


    }
}
