﻿using PhDSystem.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateUser(User user);
        Task DeleteUser(int userId);
        Task<User> GetUser(string email, string password);
        Task<UserRole> GetUserRole(int userId);
        Task UpdateUser(User user);
    }
}
