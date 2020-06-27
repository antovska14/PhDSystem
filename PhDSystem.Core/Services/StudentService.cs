using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models.Students;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITeacherRepository _teacherRepository;

        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository, ITeacherRepository teacherRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task CreateStudentAsync(StudentDetails studentCreateModel)
        {
            var password = studentCreateModel.Email.Split('@')[0];
            var user = new User() { Email = studentCreateModel.Email, Password = password, RoleId = 2 };
            var userId = await _userRepository.CreateUser(user);

            studentCreateModel.UserId = userId;
            await _studentRepository.CreateStudentAsync(studentCreateModel);
        }

        public async Task<IEnumerable<StudentListModel>> GetStudentsByTeacherUserIdAsync(int teacherUserId)
        {
            var teacherId = await _teacherRepository.GetTeacherIdByUserId(teacherUserId);
            return await _studentRepository.GetStudentsByTeacherAsync(teacherId);
        }

        public async Task UpdateStudentAsync(int studentId, StudentDetails studentUpdateModel)
        {
            var user = new User() { Id = studentUpdateModel.UserId, Email = studentUpdateModel.Email };
            await _userRepository.UpdateUser(user);
            await _studentRepository.UpdateStudentAsync(studentId, studentUpdateModel);
        }
    }
}
