using JMock.Builders.Database;
using System.Data.Common;

namespace JMock.Database
{
  public static class DBConnectionErrorMock { 


    public static DbException CreateDbException(string? message = null)
    {
      return new DatabaseErrorBuilder().SetExceptionMessage(message).Build();
    }

  }
}
