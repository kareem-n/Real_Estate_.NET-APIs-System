namespace Pro.Application.DTOs.Auth
{
    public class RegisterNewUserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string DateOfBirth { get; set; }

        public string? Address { get; set; }

        public required string Email { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public required string ConfirmPasswrd { get; set; }
    }
}
