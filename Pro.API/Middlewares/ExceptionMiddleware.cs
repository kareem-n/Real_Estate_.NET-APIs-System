
using Pro.API.Responses;
using Pro.Application.Common.Errors;

namespace Pro.API.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception Occured :{ex.Message}");
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = ApiResponse<object>.Failure(Error.Default($"{ex.Message}"), "Internal server error");

                await context.Response.WriteAsJsonAsync(response);

            }

        }
    }
}
