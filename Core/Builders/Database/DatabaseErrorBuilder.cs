using JMock.Core.Database.Exceptions;
using System.Data.Common;

namespace JMock.Core.Builders.Database
{
  public class DatabaseErrorBuilder
  {
    private string? Message;
    private int? ErrorCode;
    public DatabaseErrorBuilder SetExceptionMessage(string? message = null)
    {
      Message = message;
      return this;
    }

    public DatabaseErrorBuilder SetErrorCode(int? errorCode = null)
    {
      ErrorCode = ErrorCode;
      return this;
    }

    public DbException Build()
    {
      if (string.IsNullOrEmpty(Message)) throw new InvalidDataException("Missing message for exception");
      if (ErrorCode != null) return new CustomDbException(Message, ErrorCode.Value);
      return new CustomDbException(Message ?? "Error");
    }
  }
}
