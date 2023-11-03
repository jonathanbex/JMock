using System.Data.Common;

namespace JMock.Core.Database.Exceptions
{
  public class CustomDbException : DbException
  {
    public CustomDbException(string message) : base(message) { }
    public CustomDbException(string message,int errorCode) : base(message, errorCode) { }
  }
}
