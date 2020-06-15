using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            await _studentRepository.DeleteStudentAsync(studentId);
        }

        public async Task<Student> GetStudentAsync(int studentId)
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

        public async Task UpdateStudentAsync(int studentId, Student student)
        {
            await _studentRepository.UpdateStudentAsync(studentId, student);
        }
    }
}
