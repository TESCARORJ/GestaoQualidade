using NHibernate;
using NHibernate.Linq;
using Nuclep.GestaoQualidade.Domain.Interfaces.Identity;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity : IEntidade
    {
        private readonly ISession _session;

        public BaseRepository(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public async Task<TEntity> GetByIdAsync(long? id)
        {
            return await _session.GetAsync<TEntity>(id).ConfigureAwait(false);
        }

        public async Task<TEntity> GetByLoginAsync(string name)
        {
            return await _session.Query<TEntity>().FirstOrDefaultAsync(e => e.NomeAD == name).ConfigureAwait(false);
        }


        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _session.Query<TEntity>().ToListAsync();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _session.Query<TEntity>().FirstOrDefaultAsync(where);
        }

        public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where)
        {
            return  await _session.Query<TEntity>().Where(where).ToListAsync();
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            //using (var transaction = _session.BeginTransaction())
            //{
            //    try
            //    {
                    await _session.SaveOrUpdateAsync(entity);
                    //await _session.com. CommitAsync();
                    return entity;
                //}
                //catch (Exception ex)
                //{
                //    await transaction.RollbackAsync();
                //    throw new Exception("Erro ao salvar entidade", ex);
                //}
            //}
        }

        public async Task SaveListAsync(List<TEntity> entities)
        {
            foreach (var item in entities)
            {
                await SaveAsync(item);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _session.DeleteAsync(entity);
        }

        public async Task CommitTranAsync()
        {
            using (var transaction = _session.BeginTransaction())
            {
                await transaction.CommitAsync();
            }
        }

        public virtual void Dispose()
        {
            _session.Dispose();
        }
    }
}
