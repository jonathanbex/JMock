using JMock.Core.Database.DBSet;
using Microsoft.EntityFrameworkCore;
namespace JMock.Core.Database
{
  /// <summary>
  /// Extend this and use FakeDbSet for your own Context
  /// </summary>
  public class JMockDbContext : DbContext
  {
    public JMockDbContext() : base(null) // Pass null since we won't be using it anyway.
    {
      Entity = new FakeDbSet<object>();
    }
    public FakeDbSet<object> Entity;

    /// <summary>
    /// Fake save changes
    /// </summary>
    /// <returns></returns>
    public override int SaveChanges()
    {
      // Do nothing or return a fixed number to simulate the number of records affected.
      return 0;
    }
  }
}
