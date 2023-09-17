using JMock.Core.Database.Exceptions;
using System.Data.Common;

namespace JMock.Core.Builders.Database
{
  public class DatabaseErrorBuilder
  {
    private string? Message;

    public DatabaseErrorBuilder SetExceptionMessage(string? message = null)
    {
      Message = message;
      return this;
    }

    public DbException Build()
    {
      return new CustomDbException(Message ?? "Error");
    }
  }
}
