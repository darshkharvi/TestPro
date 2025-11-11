using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Base
{
    public interface IRepositoryCore<TEntity>
        where TEntity : class
    {
      IQueryable<TEntity> Get();

      Task<IQueryable<TEntity>> GetAsync();

      IQueryable<TEntity> GetExpandable();

      IQueryable<TEntity> Read();

      IQueryable<TEntity> RunQuery(string query);

      IQueryable<TEntity> RunQuery(string query, params object[] parameters);

      TEntity Add(TEntity entity);

      IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);

      Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

      Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities);

      Task<List<TEntity>> GetAllAsync();
      IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
      TEntity Update(TEntity entity);

      Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

      void Delete(TEntity entity);

      void Delete(IEnumerable<TEntity> entities);

      Task DeleteAsync(TEntity entity);
      object Include(Func<object, object> value);
      Task ToListAsync();
    }
  }
