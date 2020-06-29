using Microsoft.AspNetCore.Identity;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Repositories.Helpers
{
    public static class PasswordHelper
    {
        public static string GetHashedPassword(User user, string password)
        {
            var hasher = new PasswordHasher<User>();
            string hashed = hasher.HashPassword(user, password);

            return hashed;
        }

        public static bool AreHashedAndActualPasswordsEqual(User user, string hashed, string actual)
        {
            var hasher = new PasswordHasher<User>();
            bool areEqual = false;
            var verificationResult = hasher.VerifyHashedPassword(user, hashed, actual);
            if (verificationResult == PasswordVerificationResult.Success
                || verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
            {
                areEqual = true;
            }

            return areEqual;
        }
    }
}
