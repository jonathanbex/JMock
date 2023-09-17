using JMock.Core.Http.HttpMsgHandler;
using JMock.Core.Http.HttpResponses;

namespace JMock.Core.Http
{
  public static class HttpMock
  {
    /// <summary>
    /// Creates a Valid request
    /// </summary>
    /// <param name="delay">set delay for request, default 50ms</param>
    /// <param name="content">opptional content to receive in message for example json</param>
    /// <returns></returns>
    public static HttpClient CreateValidRequest(int delay = 50, string? content = null)
    {
      var httpResponse = new HttpResponseMock(delay).CreateValidRequest(content);
      var httpResponseMessageHandler = new MockHttpMessageHandler(httpResponse);
      return new HttpClient(httpResponseMessageHandler);
    }
    /// <summary>
    /// Creates an Invalid Request
    /// </summary>
    /// <param name="delay">set delay for request, default 50ms</param>
    /// <param name="responseCode">Response conde for invalid request, default is 400</param>
    /// <returns></returns>
    public static HttpClient CreateInvalidRequest(int delay = 50, int responseCode = 400)
    {
      var httpResponse = new HttpResponseMock(delay).CreateFailedRequest(responseCode);
      var httpResponseMessageHandler = new MockHttpMessageHandler(httpResponse);
      return new HttpClient(httpResponseMessageHandler);

    }
  }
}
