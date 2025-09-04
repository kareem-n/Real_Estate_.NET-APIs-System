namespace Pro.Application.DTOs.Auth
{
    public record LoginResponse(
        string accessToken,
        string userId,
        string email,
        string username

        )
    {
    }
}
