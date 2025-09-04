using Pro.Application.Common.Errors;

namespace Pro.API.Responses
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool IsSuccess { get; set; }

        public Error? Error { get; set; }

        public static ApiResponse<T> Success(T data, string message = "Success")
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message,
                Error = null!
            };
        }

        public static ApiResponse<T> Failure(Error error, string message = "Failed")
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Message = message,
                Error = error,
                Data = default!
            };
        }


    }
}
