using PhDSystem.Data.Entities;

namespace PhDSystem.Core.Models
{
    public class UserAuth
    {
        public string Email { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Role { get; set; }

        public UserAuth()
        {
            Email = "Not authorized";
            BearerToken = string.Empty;
        }
    }
}
