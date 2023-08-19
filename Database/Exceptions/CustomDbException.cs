using System.Data.Common;

namespace JMock.Database.Exceptions
{
  public class CustomDbException : DbException
  {
    public CustomDbException(string message) : base(message) { }
  }
}
