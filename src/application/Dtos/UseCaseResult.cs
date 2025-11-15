using System.Net;

namespace application.Dtos
{
    public class UseCaseResult
    {
        public object? Content { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}