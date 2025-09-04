using Microsoft.AspNetCore.Mvc;
using Pro.Application.Common.Results;

namespace Pro.API.Extentions
{
    public static class ToActionResultExtention
    {
        public static IActionResult ToActionResult<T>(this ServiceResult<T> response)
        {
            if (response.IsSuccess)
            {
                return new OkObjectResult(response.ToApiResponse());
            }

            return MapErrorResultObjects(response);

        }

        private static IActionResult MapErrorResultObjects<T>(ServiceResult<T> response)
        {
            return response.Error!.Code switch
            {
                "NOTFOUND" => new NotFoundObjectResult(response.ToApiResponse()),
                "BadRequest" => new BadRequestObjectResult(response.ToApiResponse()),
                "Unauthorized" => new UnauthorizedObjectResult(response.ToApiResponse()),
                _ => new BadRequestObjectResult(response.ToApiResponse())
            };


        }
    }
}
