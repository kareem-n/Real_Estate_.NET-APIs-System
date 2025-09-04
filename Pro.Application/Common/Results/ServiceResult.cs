using Pro.Application.Common.Errors;

namespace Pro.Application.Common.Results
{
    public class ServiceResult<TData>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } = string.Empty;

        public Error? Error { get; set; }

        public TData? Result { get; set; }




        private ServiceResult(bool isSuccess, TData data, string message, Error error)
        {
            IsSuccess = isSuccess;
            Result = data;
            Error = error;
            Message = message;
        }

        public static ServiceResult<TData> Success(TData data, string message)
            => new(true, data, message, default!);

        public static ServiceResult<TData> Failure(Error error, string message)
            => new(false, default!, message, error);

    }
}
