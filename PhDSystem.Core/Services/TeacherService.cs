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

        public TeacherService(ITeacherRepository teacherRepository, IUserRepository userRepository)
        {
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
        }

        public async Task CreateTeacherAsync(TeacherDetails teacherDetails)
        {
            var password = teacherDetails.Email.Split('@')[0];
            var user = new User() { Email = teacherDetails.Email, Password = password, RoleId = 3 };
            var userId = await _userRepository.CreateUser(user);

            teacherDetails.UserId = userId;
            await _teacherRepository.CreateTeacherAsync(teacherDetails);
        }

        public async Task DeleteTeacherAsync(int teacherId)
        {
            await _teacherRepository.DeleteTeacherAsync(teacherId);
        }

        public async Task<Teacher> GetTeacherAsync(int teacherId)
        {
            return await _teacherRepository.GetTeacherAsync(teacherId);
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            return await _teacherRepository.GetTeachersAsync();
        }

        public async Task UpdateTeacherAsync(int teacherId, TeacherDetails teacherDetails)
        {
            var user = new User() { Email = teacherDetails.Email };
            await _userRepository.UpdateUser(user);
            await _teacherRepository.UpdateTeacherAsync(teacherId, teacherDetails);
        }
    }
}
