namespace JMock.Http.Client
{
  public class MockHttpClient
  {
    public HttpClient SetupHttpClient(HttpMessageHandler? handler = null)
    {
      if (handler != null) return new HttpClient(handler);
      return new HttpClient();
    }
  }
}
