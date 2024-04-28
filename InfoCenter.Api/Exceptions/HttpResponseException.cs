namespace InfoCenter.Api.Exceptions;

public class HttpResponseException : Exception
{
    public HttpResponseException(int statusCode, string message)
        : base(message)
        {
            StatusCode = statusCode;
        }

    public int StatusCode { get; }
}

// public class HttpResponseException : Exception
// {
//     public HttpResponseException(int statusCode, object? value = null) =>
//         (StatusCode, Value) = (statusCode, value);

//     public int StatusCode { get; }

//     public object? Value { get; }
// }