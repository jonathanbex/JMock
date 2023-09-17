using JMock.Core.Http;

namespace JMock.Examples
{
  public class ExampleMockHttpRequest
  {
    public static HttpClient _invalidRequestHttpClient = HttpMock.CreateInvalidRequest(20000, 408);
    public static HttpClient _validRequestHttpClient = HttpMock.CreateValidRequest();

    public async Task RunValidRequest()
    {

      var resp = await _validRequestHttpClient.GetAsync("");
      resp.EnsureSuccessStatusCode();
    }
    public async Task RunInvalidRequest()
    {
      var resp = await _invalidRequestHttpClient.GetAsync("");
      resp.EnsureSuccessStatusCode();
    }
  }
}
