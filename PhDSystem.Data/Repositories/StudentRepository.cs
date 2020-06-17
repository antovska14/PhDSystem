using Microsoft.EntityFrameworkCore;
using PhDSystem.Core.Services.Models;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PhdSystemDbContext _context;

        public StudentRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudentAsync(StudentDetails studentDetails)
        {
            //Add student
            var formOfEducation = await GetFormOfEducationAsync(studentDetails.FormOfEducation);
            var student = new Student()
            {
                UserId = studentDetails.UserId,
                FirstName = studentDetails.FirstName,
                MiddleName = studentDetails.MiddleName,
                LastName = studentDetails.LastName,
                SpecialtyName = studentDetails.SpecialtyName,
                FormOfEducationId = formOfEducation.Id,
                CurrentYear = studentDetails.CurrentYear,
                FacultyCouncilChosenDate = studentDetails.FacultyCouncilChosenDate,
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            //Assign supervisors
            var teacherIds = studentDetails.Teachers.Select(t => t.Id).ToArray();

            foreach (var teacherId in teacherIds)
            {
                var studentTeacherRecord = new StudentTeacher() { StudentId = student.Id, TeacherId = teacherId };
                _context.StudentTeachers.Add(studentTeacherRecord);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Id == studentId);
            student.IsDeleted = true;

            var user = await (from s in _context.Students
                              join u in _context.Users on s.UserId equals u.Id
                              where s.Id == studentId
                              select u).SingleOrDefaultAsync();

            user.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentAsync(int studentId)
        {
            var student = await _context.Students
                .Where(s => s.Id == studentId && s.IsDeleted == false)
                .SingleOrDefaultAsync();

            var formOfEducation = await _context.FormsOfEducation
                                 .Where(foe => foe.Id.Equals(student.FormOfEducationId))
                                 .SingleOrDefaultAsync();

            var teachers = await (from t in _context.Teachers
                                  join st in _context.StudentTeachers on t.Id equals st.TeacherId
                                  where st.StudentId == studentId
                                  select new TeacherDetails()
                                  {
                                      Id = t.Id,
                                      FirstName = t.FirstName,
                                      MiddleName = t.MiddleName,
                                      LastName = t.LastName,
                                  }).ToListAsync();

            return new StudentDetails()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                SpecialtyName = student.SpecialtyName,
                FormOfEducation = formOfEducation.Name,
                CurrentYear = student.CurrentYear,
                FacultyCouncilChosenDate = student.FacultyCouncilChosenDate,
                Teachers = teachers
            };
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsBySupervisorAsync(int supervisorId)
        {
            return await (from s in _context.Students
                          join st in _context.StudentTeachers on s.Id equals st.StudentId
                          join t in _context.Teachers on st.TeacherId equals t.Id
                          where t.Id == supervisorId && !s.IsDeleted
                          select s).ToListAsync();
        }

        public async Task UpdateStudentAsync(int studentId, StudentDetails studentDetails)
        {
            var existingStudent = _context.Students.SingleOrDefault(s => s.Id == studentId);

            existingStudent.FirstName = studentDetails.FirstName;
            existingStudent.MiddleName = studentDetails.MiddleName;
            existingStudent.LastName = studentDetails.LastName;
            existingStudent.SpecialtyName = studentDetails.SpecialtyName;
            existingStudent.FacultyCouncilChosenDate = studentDetails.FacultyCouncilChosenDate;

            var formOfEducation = await GetFormOfEducationAsync(studentDetails.FormOfEducation);
            existingStudent.FormOfEducationId = formOfEducation.Id;
            existingStudent.CurrentYear = studentDetails.CurrentYear;

            await _context.SaveChangesAsync();
        }

        private async Task<FormOfEducation> GetFormOfEducationAsync(string formOfEducationName)
        {
            return await _context.FormsOfEducation
                                 .Where(foe => foe.Name.Equals(formOfEducationName))
                                 .SingleOrDefaultAsync();
        }
    }
}