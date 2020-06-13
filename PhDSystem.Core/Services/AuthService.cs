using Microsoft.IdentityModel.Tokens;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserRepository _userRepository;

        public AuthService(JwtSettings jwtSettings, IUserRepository userRepository)
        {
            _jwtSettings = jwtSettings;
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
            userAuth.BearerToken = BuildJwtToken(userAuth);

            var claims = await GetUserClaims(user);

            foreach (UserClaim claim in claims)
            {
                typeof(UserAuth).GetProperty(claim.ClaimType)
                                .SetValue(userAuth, claim.ClaimValue, null);
            }

            return userAuth;
        }

        private string BuildJwtToken(UserAuth userAuth)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            // Create the standard JWT claims
            List<Claim> jwtClaims = new List<Claim>();
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, userAuth.UserName));
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            // Add custom claims
            jwtClaims.Add(new Claim("isAuthenticated", userAuth.IsAuthenticated.ToString().ToLower()));
            jwtClaims.Add(new Claim("canAccessStudents", userAuth.IsAuthenticated.ToString().ToLower()));
            jwtClaims.Add(new Claim("canAccessSupervisors", userAuth.IsAuthenticated.ToString().ToLower()));
            jwtClaims.Add(new Claim("canAddStudents", userAuth.IsAuthenticated.ToString().ToLower()));
            jwtClaims.Add(new Claim("canAddSupervisors", userAuth.IsAuthenticated.ToString().ToLower()));
            jwtClaims.Add(new Claim("canDeleteStudents", userAuth.IsAuthenticated.ToString().ToLower()));
            jwtClaims.Add(new Claim("canDeleteSupervisors", userAuth.IsAuthenticated.ToString().ToLower()));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: jwtClaims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_jwtSettings.MinutesToExpiration),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
