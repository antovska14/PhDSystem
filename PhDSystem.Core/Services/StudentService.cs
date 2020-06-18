using PhDSystem.Core.Constants;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Core.Services.Models;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;

        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }

        public async Task CreateStudentAsync(StudentDetails studentDetails)
        {
            var password = studentDetails.Email.Split('@')[0];
            var user = new User() { Email = studentDetails.Email, Password = password, RoleId = 2 };
            var userId = await _userRepository.CreateUser(user);

            studentDetails.UserId = userId;
            await _studentRepository.CreateStudentAsync(studentDetails);
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            await _studentRepository.DeleteStudentAsync(studentId);
        }

        public async Task<StudentDetails> GetStudentAsync(int studentId)
        {
            return await _studentRepository.GetStudentAsync(studentId);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsBySupervisorAsync(int supervisorId)
        {
            return await _studentRepository.GetStudentsBySupervisorAsync(supervisorId);
        }

        public async Task UpdateStudentAsync(int studentId, StudentDetails studentDetails)
        {
            var user = new User() { Id = studentDetails.UserId, Email = studentDetails.Email };
            await _userRepository.UpdateUser(user);

            await _studentRepository.UpdateStudentAsync(studentId, studentDetails);
        }
    }
}
