using DataCore.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore
{
    public class TestProUnitOfWork: ITestProUnitOfWork
    {
    private static readonly object _createRepositoryLock = new();
    private readonly Dictionary<Type, object> _repositories = new();
    private bool _disposed;
    public DbContext dfContext { get; }
    public object Account => throw new NotImplementedException();
    public object Client => throw new NotImplementedException();

    public TestProUnitOfWork(TestProContext context)
    {
      dfContext = context;
    }

    public void Dispose()
    {
      if (!_disposed)
      {
        Dispose(true);
      }

      GC.SuppressFinalize(this);
    }

    public IRepositoryCore<TEntity> Repository<TEntity>()
        where TEntity : class
    {
      if (!_repositories.ContainsKey(typeof(TEntity)))
      {
        lock (_createRepositoryLock)
        {
          if (!_repositories.ContainsKey(typeof(TEntity)))
          {
            CreateRepository<TEntity>();
          }
        }
      }

      return _repositories[typeof(TEntity)] as IRepositoryCore<TEntity>;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
      return dfContext.Database.CurrentTransaction == null
          ? await dfContext.Database.BeginTransactionAsync()
          : new NestedTransaction();
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
      return dfContext.Database.CommitTransactionAsync(cancellationToken);
    }

    public Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
      return dfContext.Database.RollbackTransactionAsync(cancellationToken);
    }

    public Task SaveAsync(CancellationToken cancellationToken = default)
    {
      return dfContext.SaveChangesAsync(cancellationToken);
    }

    public void Save()
    {
      dfContext.SaveChanges();
    }

    public int ExecuteQuery(string query, params object[] parameters)
    {
      return dfContext.Database.ExecuteSqlRaw(query, parameters);
    }

    public async Task<int> ExecuteQueryAsync(string query, params object[] parameters)
    {
      return await dfContext.Database.ExecuteSqlRawAsync(query, parameters);
    }

    public string GetTableNameWithSchema<T>()
    {
      var entityType = dfContext.Model.FindEntityType(typeof(T));

      return $"{entityType.GetSchema()}.{entityType.GetTableName()}";
    }

    public void Detach<T>(T entity)
    {
      dfContext.Entry(entity).State = EntityState.Detached;
    }

    public void Attach<T>(T entity)
    {
      dfContext.Entry(entity).State = EntityState.Modified;
    }

    private void CreateRepository<TEntity>()
        where TEntity : class
    {
      _repositories.Add(typeof(TEntity), new Repository<TEntity>(dfContext));
    }
    private void Dispose(bool disposing)
    {
      if (disposing)
      {
        dfContext?.Dispose();
        _disposed = true;
      }
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
      return dfContext.SaveChangesAsync();
    }
  }
}
