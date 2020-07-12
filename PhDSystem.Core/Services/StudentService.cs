using PhDSystem.Core.Services.Helpers;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models.Students;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task CreateStudentAsync(StudentDetails studentCreateModel)
        {
            var generatedPassword = AuthHelper.GeneratePassword();
            var email = studentCreateModel.Email;
            var user = new User() { Email = email, Password = generatedPassword, RoleId = 2 };

            var userId = await _userRepository.CreateUser(user);

            studentCreateModel.UserId = userId;
            await _studentRepository.CreateStudentAsync(studentCreateModel);

            await _emailService.NotifyUserForInitialCredentials(email, generatedPassword);
        }

        public async Task UpdateStudentAsync(int studentId, StudentDetails studentUpdateModel)
        {
            var user = new User() { Id = studentUpdateModel.UserId, Email = studentUpdateModel.Email };
            await _userRepository.UpdateUser(user);
            await _studentRepository.UpdateStudentAsync(studentId, studentUpdateModel);
        }
    }
}
