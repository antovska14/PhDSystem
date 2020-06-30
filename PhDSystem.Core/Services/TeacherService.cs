using PhDSystem.Core.Services.Helpers;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
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
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task CreateTeacherAsync(TeacherDetails teacherDetails)
        {
            var password = AuthHelper.GeneratePassword();
            var user = new User() { Email = teacherDetails.Email, Password = password, RoleId = 3 };
            await _emailService.NotifyUserForInitialCredentials(user);

            var userId = await _userRepository.CreateUser(user);

            teacherDetails.UserId = userId;
            await _teacherRepository.CreateTeacherAsync(teacherDetails);
        }

        public async Task DeleteTeacherAsync(int teacherId)
        {
            await _teacherRepository.DeleteTeacherAsync(teacherId);
        }

        public async Task<TeacherDetails> GetTeacherAsync(int teacherId)
        {
            return await _teacherRepository.GetTeacherAsync(teacherId);
        }

        public async Task<IEnumerable<TeacherDetails>> GetTeachersAsync()
        {
            return await _teacherRepository.GetTeachersAsync();
        }

        public async Task UpdateTeacherAsync(int teacherId, TeacherDetails teacherDetails)
        {
            var user = new User() { Id = teacherDetails.UserId, Email = teacherDetails.Email };
            await _userRepository.UpdateUser(user);
            await _teacherRepository.UpdateTeacherAsync(teacherId, teacherDetails);
        }
    }
}
