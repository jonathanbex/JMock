using JMock.Database;
using JMock.Database.DBSet;
using Microsoft.EntityFrameworkCore;

namespace JMock.Examples
{
  public class ExampleMockDbContext : JMockDbContext
  {
    public DbSet<FakeModel> FakeModel { get; set; }
    public ExampleMockDbContext()
    {
      FakeModel = new FakeDbSet<FakeModel>();
    }
  }

  public class FakeModel
  {
    public string Id { get; set; }
    public decimal Val { get; set; }
  }
}
