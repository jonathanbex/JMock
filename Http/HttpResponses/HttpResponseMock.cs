namespace JMock.Http.HttpResponses
{
    public class HttpResponseMock
    {
        private int Delay { get; set; }
        private static HttpClient client = new HttpClient();
        public HttpResponseMock(int? delay = null)
        {
            Delay = delay ?? 50;
        }
        /// <summary>
        /// Create a Valid Http request
        /// </summary>
        /// <param name="content">manually set content for example if you want a json object back</param>
        /// <returns></returns>
        public HttpResponseMessage CreateValidRequest(string? content = null)
        {
            HttpResponseMessage? message = ConstructResponse();
            HandleDelay();
            return message;
        }

        /// <summary>
        /// Create a Failed Http request
        /// </summary>
        /// <param name="responseCode">status code, recommended codes to use is 400-500</param>
        /// <returns></returns>
        public HttpResponseMessage CreateFailedRequest(int responseCode = 400)
        {
            HttpResponseMessage? message = ConstructResponse(responseCode);
            HandleDelay();
            return message;
        }

        /// <summary>
        /// Creates an Unauthorized request
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage CreateUnauthorizedRequest()
        {
            HttpResponseMessage? message = ConstructResponse(401);
            HandleDelay();
            return message;
        }

        private void HandleDelay()
        {
            if (Delay == 0) return;
            Thread.Sleep(Delay);
        }
        private HttpResponseMessage ConstructResponse(int responseCode = 200, string? content = null)
        {
            switch (responseCode)
            {
                case 200: return HttpResponseHelper.ConstructOkRequest(content);
                case 400: return HttpResponseHelper.ConstructBadRequest(content);
                case 401: return HttpResponseHelper.ConstructUnauthorizedRequest(content);
                case 404: return HttpResponseHelper.ConstructNotFoundRequest(content);
                case 500: return HttpResponseHelper.ConstructInternalErrorRequest(content);
                default: return HttpResponseHelper.ConstructOkRequest(content);
            }
        }
    }
}
