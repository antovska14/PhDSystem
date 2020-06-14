using PhDSystem.Data.Models;

namespace PhDSystem.Core.Models
{
    public class UserAuth
    {
        public string Username { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Role { get; set; }

        public UserAuth()
        {
            Username = "Not authorized";
            BearerToken = string.Empty;
        }
    }
}
