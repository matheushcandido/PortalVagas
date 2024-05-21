using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UseCaseResponse<T>
    {
        public T? Response { get; set; }
        public HttpStatusCode StatusCode { get; init; }
        public IEnumerable<string> Errors { get; init; } = null!;
        public bool IsSuccess => !Errors.Any();

        public static UseCaseResponse<T> Success(T response, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new UseCaseResponse<T>()
            {
                Response = response,
                StatusCode = statusCode,
                Errors = Array.Empty<string>()
            };
        }

        public static UseCaseResponse<T> Fail(IEnumerable<string> errors, HttpStatusCode statusCode)
        {
            return new UseCaseResponse<T>()
            {
                Response = default,
                Errors = errors,
                StatusCode = statusCode
            };
        }

        public static UseCaseResponse<T> Fail(string error, HttpStatusCode statusCode)
        {
            return Fail(new[] { error }, statusCode);
        }

        public static UseCaseResponse<T> InternalServerError(string error)
            => Fail(error, HttpStatusCode.InternalServerError);

        public static UseCaseResponse<T> BadRequest(string error)
            => Fail(error, HttpStatusCode.BadRequest);

        public static UseCaseResponse<T> BadRequest(IEnumerable<string> error)
            => Fail(error, HttpStatusCode.BadRequest);
    }
}
