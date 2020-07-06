namespace PhDSystem.Api.Models
{
    public class UserAuth
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string BearerToken { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Role { get; set; }

        public bool PasswordSet { get; set; }

        public UserAuth()
        {
            Email = "Not authorized";
            BearerToken = string.Empty;
        }
    }
}
