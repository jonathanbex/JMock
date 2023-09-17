using JMock.Core.Builders.Http;
using System.Net;

namespace JMock.Core.Http.HttpResponses
{
  public static class HttpResponseHelper
  {
    public static HttpResponseMessage ConstructOkRequest(string? content = null)
    {
      return new HttpResponseMessageBuilder()
     .SetStatus(HttpStatusCode.OK)
     .SetContent(new StringContent(content ?? "Request was successful."))
     .Build();
    }
    public static HttpResponseMessage ConstructBadRequest(string? content = null)
    {
      return new HttpResponseMessageBuilder()
          .SetStatus(HttpStatusCode.BadRequest)
          .SetContent(new StringContent(content ?? "The request was invalid or cannot be otherwise served."))
          .Build();
    }

    public static HttpResponseMessage ConstructUnauthorizedRequest(string? content = null)
    {
      return new HttpResponseMessageBuilder()
          .SetStatus(HttpStatusCode.Unauthorized)
          .SetContent(new StringContent(content ?? "Authorization has been denied for this request."))
          .Build();
    }

    public static HttpResponseMessage ConstructNotFoundRequest(string? content = null)
    {
      return new HttpResponseMessageBuilder()
           .SetStatus(HttpStatusCode.NotFound)
           .SetContent(new StringContent(content ?? "The requested resource could not be found."))
           .Build();
    }
    public static HttpResponseMessage ConstrucTimeoutRequest(string? content = null)
    {
      return new HttpResponseMessageBuilder()
           .SetStatus(HttpStatusCode.RequestTimeout)
           .SetContent(new StringContent(content ?? "The requested resource timed out."))
           .Build();
    }
    public static HttpResponseMessage ConstructInternalErrorRequest(string? content = null)
    {
      return new HttpResponseMessageBuilder()
          .SetStatus(HttpStatusCode.InternalServerError)
          .SetContent(new StringContent(content ?? "An error occurred on the server and the request could not be completed."))
          .Build();
    }
  }
}
