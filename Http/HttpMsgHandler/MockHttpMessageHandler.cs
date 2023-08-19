using System.Net;

namespace JMock.Http.HttpMsgHandler
{
  public class MockHttpMessageHandler : HttpMessageHandler
  {
    private readonly HttpResponseMessage _response;

    public MockHttpMessageHandler(HttpResponseMessage response)
    {
      _response = response ?? throw new ArgumentNullException(nameof(response));
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

      return Task.FromResult(_response);
    }
  }
}
