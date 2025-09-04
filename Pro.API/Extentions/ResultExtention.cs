using Pro.API.Responses;
using Pro.Application.Common.Results;

namespace Pro.API.Extentions
{
    public static class ResultExtention
    {
        public static ApiResponse<T> ToApiResponse<T>(this ServiceResult<T> result)
        {
            if (result.IsSuccess)
            {
                return ApiResponse<T>.Success(result.Result!, result.Message);
            }
            else
            {
                return ApiResponse<T>.Failure(result.Error!, result.Message);
            }
        }

    }
}
