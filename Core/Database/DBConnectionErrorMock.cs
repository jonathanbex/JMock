using JMock.Core.Builders.Database;
using System.Data.Common;

namespace JMock.Core.Database
{
  public static class DBConnectionErrorMock { 


    public static DbException CreateDbException(string? message = null)
    {
      return new DatabaseErrorBuilder().SetExceptionMessage(message).Build();
    }

  }
}
