using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;
using System.Linq.Expressions;

namespace JMock.Core.Database.DBSet
{
  public class FakeDbSet<T> : DbSet<T>, IQueryable<T>, IEnumerable<T> where T : class
  {
    private readonly List<T> _data;
    private readonly IQueryable<T> _queryable;

    public override IEntityType EntityType => throw new NotImplementedException();

    public FakeDbSet()
    {
      _data = new List<T>();
      _queryable = _data.AsQueryable();
    }

    public override EntityEntry<T> Add(T item)
    {
      _data.Add(item);
      return null;
    }


    public IEnumerator<T> GetEnumerator()
    {
      return _data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _data.GetEnumerator();
    }

    public IQueryable<T> AsQueryable()
    {
      return _data.AsQueryable();
    }
    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      // Using a simple implementation for async enumeration
      return new AsyncEnumeratorWrapper<T>(_data.GetEnumerator());
    }
    public Type ElementType => _queryable.ElementType;

    public Expression Expression => _queryable.Expression;

    public IQueryProvider Provider => _queryable.Provider;

    private class AsyncEnumeratorWrapper<TItem> : IAsyncEnumerator<TItem>
    {
      private readonly IEnumerator<TItem> _inner;

      public AsyncEnumeratorWrapper(IEnumerator<TItem> inner)
      {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
      }

      public TItem Current => _inner.Current;

      public ValueTask DisposeAsync()
      {
        _inner.Dispose();
        return ValueTask.CompletedTask;
      }

      public ValueTask<bool> MoveNextAsync()
      {
        return new ValueTask<bool>(_inner.MoveNext());
      }
    }
  }

}
