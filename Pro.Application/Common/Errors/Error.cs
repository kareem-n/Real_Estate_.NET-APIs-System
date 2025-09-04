namespace Pro.Application.Common.Errors
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public IDictionary<string, IEnumerable<string>> Errors { get; set; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static Error NotFound(string message)
        => new("NOTFOUND", message);

        public static Error BadRequest(string message)
            => new("BAD_REQUEST", message);

        public static Error Conflict(string message)
            => new("CONFLICT", message);


        public static Error Unauthorized(string message)
        => new("Unauthorized", message);

        public static Error Default(string message)
            => new("SERVER_ERROR", message);

        public static Error Validation(string message, IDictionary<string, IEnumerable<string>> errors)
            => new("VALIDATION_ERROR", message)
            {
                Errors = errors
            };


    }
}
