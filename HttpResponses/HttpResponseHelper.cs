using JMock.Builders.Http;
using System.Net;

namespace JMock.HttpResponses
{
  public static class HttpResponseHelper
  {
    public static HttpResponseMessage ConstructOkRequest()
    {
      return new HttpResponseMessageBuilder()
     .SetStatus(HttpStatusCode.OK)
     .SetContent(new StringContent("Request was successful."))
     .Build();
    }
    public static HttpResponseMessage ConstructBadRequest()
    {
      return new HttpResponseMessageBuilder()
          .SetStatus(HttpStatusCode.BadRequest)
          .SetContent(new StringContent("The request was invalid or cannot be otherwise served."))
          .Build();
    }
    public static HttpResponseMessage ConstructNotFoundRequest()
    {
      return new HttpResponseMessageBuilder()
           .SetStatus(HttpStatusCode.NotFound)
           .SetContent(new StringContent("The requested resource could not be found."))
           .Build();
    }
    public static HttpResponseMessage ConstructInternalErrorRequest()
    {
      return new HttpResponseMessageBuilder()
          .SetStatus(HttpStatusCode.InternalServerError)
          .SetContent(new StringContent("An error occurred on the server and the request could not be completed."))
          .Build();
    }
  }
}
