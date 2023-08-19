namespace JMock.Examples
{
  public class ExampleUsingMockedDb
  {
    ExampleMockDbContext DBContext;
    public ExampleUsingMockedDb(ExampleMockDbContext db)
    {
      DBContext = db;
    }
    public void Run()
    {
      var entry = new FakeModel { Id = Guid.NewGuid().ToString(), Val = 100 };
      DBContext.Add(entry);

      var addedEntry = DBContext.FakeModel.FirstOrDefault(x => x.Id == entry.Id);

    }
  }
}
