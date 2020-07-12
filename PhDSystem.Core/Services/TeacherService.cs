using PhDSystem.Core.Services.Helpers;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public TeacherService(ITeacherRepository teacherRepository, IUserRepository userRepository, IEmailService emailService)
        {
            _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task CreateTeacherAsync(TeacherDetails teacherDetails)
        {
            string generatedPassword = AuthHelper.GeneratePassword();
            string email = teacherDetails.Email;
            var user = new User() { Email = email, Password = generatedPassword, RoleId = 3 };

            var userId = await _userRepository.CreateUser(user);

            teacherDetails.UserId = userId;
            await _teacherRepository.CreateTeacherAsync(teacherDetails);

            await _emailService.NotifyUserForInitialCredentials(email, generatedPassword);
        }

        public async Task UpdateTeacherAsync(int teacherId, TeacherDetails teacherDetails)
        {
            var user = new User() { Id = teacherDetails.UserId, Email = teacherDetails.Email };
            await _userRepository.UpdateUser(user);
            await _teacherRepository.UpdateTeacherAsync(teacherId, teacherDetails);
        }
    }
}
