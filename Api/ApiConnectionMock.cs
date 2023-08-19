using JMock.Builders.Http;
using JMock.HttpRespones;
using System.Net;

namespace JMock.Api
{
  public class ApiConnectionMock
  {
    private int Delay { get; set; }
    private static HttpClient client = new HttpClient();
    public ApiConnectionMock(int? delay = null)
    {
      Delay = delay ?? 250;
    }

    public HttpResponseMessage CreateValidRequest<T>()
    {
      HttpResponseMessage? message = ConstructResponse();
      HandleDelay();
      return message;
    }

    public HttpResponseMessage CreateFailedRequest<T>(int responseCode = 400)
    {
      HttpResponseMessage? message = ConstructResponse(responseCode);
      HandleDelay();
      return message;
    }

    private void HandleDelay()
    {
      if (Delay == 0) return;
      Thread.Sleep(Delay);
    }
    private HttpResponseMessage ConstructResponse(int responseCode = 200)
    {
      switch (responseCode)
      {
        case (200): return HttpResponseHelper.ConstructOkRequest();
        case (400): return HttpResponseHelper.ConstructBadRequest();
        case (404): return HttpResponseHelper.ConstructNotFoundRequest();
        case (500): return HttpResponseHelper.ConstructInternalErrorRequest();
        default: return HttpResponseHelper.ConstructOkRequest();
      }
    }
  }
}
