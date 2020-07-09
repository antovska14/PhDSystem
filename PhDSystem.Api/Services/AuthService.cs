using Microsoft.IdentityModel.Tokens;
using PhDSystem.Api.Models;
using PhDSystem.Api.Services.Interfaces;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhDSystem.Api.Services
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

        public async Task<UserAuth> ValidateUserAsync(User user)
        {
            User existingUser = await _userRepository.GetUser(user.Email, user.Password);
            if (existingUser != null)
            {
                return await BuildUserAuthObjectAsync(existingUser);
            }

            return null;
        }

        private async Task<UserRole> GetUserRoleAsync(User user)
        {
            return await _userRepository.GetUserRole(user.Id);
        }

        private async Task<UserAuth> BuildUserAuthObjectAsync(User user)
        {
            UserAuth userAuth = new UserAuth
            {
                Id = user.Id,
                Email = user.Email,
                PasswordSet = user.PasswordSet,
                IsAuthenticated = true
            };
            var userRole = await GetUserRoleAsync(user);
            userAuth.Role = userRole.Name;
            userAuth.BearerToken = BuildJwtTokenAsync(userAuth);

            return userAuth;
        }

        private string BuildJwtTokenAsync(UserAuth userAuth)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            // Create the standard JWT claims
            List<Claim> jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userAuth.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                // Add custom claims
                new Claim("id", userAuth.Id.ToString()),
                new Claim("email", userAuth.Email),
                new Claim("role", userAuth.Role),
                new Claim("passwordSet", userAuth.PasswordSet.ToString().ToLower()),
                new Claim("isAuthenticated", userAuth.IsAuthenticated.ToString().ToLower())
            };

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
