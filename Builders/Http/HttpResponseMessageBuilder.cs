using System.Net;
using System.Net.Http.Headers;

namespace JMock.Builders.Http
{
  public class HttpResponseMessageBuilder
  {
    private HttpStatusCode _httpStatusCode = HttpStatusCode.OK;
    private HttpContent _content;
    private HttpResponseHeaders _headers;
    private HttpRequestMessage _requestMessage;
    private string _reasonPhrase;
    private Version _version;

    public HttpResponseMessageBuilder SetStatus(HttpStatusCode statusCode)
    {
      _httpStatusCode = statusCode;
      return this;
    }

    public HttpResponseMessageBuilder SetContent(HttpContent content)
    {
      _content = content;
      return this;
    }

    public HttpResponseMessageBuilder SetHeaders(HttpResponseHeaders headers)
    {
      _headers = headers;
      return this;
    }

    public HttpResponseMessageBuilder SetRequestMessage(HttpRequestMessage requestMessage)
    {
      _requestMessage = requestMessage;
      return this;
    }

    public HttpResponseMessageBuilder SetReasonPhrase(string reasonPhrase)
    {
      _reasonPhrase = reasonPhrase;
      return this;
    }

    public HttpResponseMessageBuilder SetVersion(Version version)
    {
      _version = version;
      return this;
    }

    public HttpResponseMessage Build()
    {
      var response = new HttpResponseMessage(_httpStatusCode)
      {
        Content = _content,
        RequestMessage = _requestMessage,
        ReasonPhrase = _reasonPhrase,
        Version = _version ?? new Version(1, 1)  // defaulting to HTTP 1.1
      };

      if (_headers != null)
      {
        foreach (var header in _headers)
        {
          response.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
      }

      return response;
    }
  }
}
