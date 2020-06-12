using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserAuth> ValidateUser(User user)
        {
            User existingUser = await _userRepository.GetUser(user.UserName, user.Password);
            if (existingUser != null)
            {
                return await BuildUserAuthObject(existingUser);
            }

            return null;
        }

        private async Task<IEnumerable<UserClaim>> GetUserClaims(User user)
        {
            return await _userRepository.GetUserClaims(user.Id);
        }

        private async Task<UserAuth> BuildUserAuthObject(User user)
        {
            UserAuth userAuth = new UserAuth();

            userAuth.UserName = user.UserName;
            userAuth.IsAuthenticated = true;
            userAuth.BearerToken = new Guid().ToString();

            var claims = await GetUserClaims(user);

            foreach (UserClaim claim in claims)
            {
                typeof(UserAuth).GetProperty(claim.ClaimType)
                                .SetValue(userAuth, claim.ClaimValue, null);
            }

            return userAuth;
        }
    }
}
