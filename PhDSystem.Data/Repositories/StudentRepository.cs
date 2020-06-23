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

            // Add student and save, so the student id is created
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            // Assign supervisors
            var teacherIds = studentDetails.Teachers.Select(t => t.Id).ToArray();
            AddStudentTeacherRecordsForStudent(teacherIds, student.Id);

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
            var studentDetails = await (from s in _context.Students
                                        join u in _context.Users on s.UserId equals u.Id
                                        join foe in _context.FormsOfEducation on s.FormOfEducationId equals foe.Id
                                        where s.Id == studentId && s.IsDeleted == false
                                        select new StudentDetails 
                                        {
                                            Id = s.Id,
                                            UserId = u.Id,
                                            FirstName = s.FirstName,
                                            MiddleName = s.MiddleName,
                                            LastName = s.LastName,
                                            Email = u.Email,
                                            SpecialtyName = s.SpecialtyName,
                                            FormOfEducation = foe.Name,
                                            CurrentYear = s.CurrentYear,
                                            FacultyCouncilChosenDate = s.FacultyCouncilChosenDate,
                                            Teachers = (from st in _context.StudentTeachers
                                                        join t in _context.Teachers on st.TeacherId equals t.Id
                                                        select new TeacherDetails 
                                                        {
                                                            Id = t.Id,
                                                            FirstName = t.FirstName,
                                                            MiddleName = t.MiddleName,
                                                            LastName = t.LastName,
                                                            Degree = t.Degree,
                                                            Title = t.Title
                                                        }).ToList()
                                        }).SingleOrDefaultAsync();

            return studentDetails;
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

            await RemoveStudentTeacherRecords(studentId);

            var teacherIds = studentDetails.Teachers.Select(t => t.Id).ToArray();
            AddStudentTeacherRecordsForStudent(teacherIds, studentId);

            await _context.SaveChangesAsync();
        }

        private async Task<FormOfEducation> GetFormOfEducationAsync(string formOfEducationName)
        {
            return await _context.FormsOfEducation
                                 .Where(foe => foe.Name.Equals(formOfEducationName))
                                 .SingleOrDefaultAsync();
        }

        private async Task<PhdProgram> GetPhdProgramAsync(string phdProgramName)
        {
            return await _context.PhdPrograms
                                 .Where(foe => foe.Name.Equals(phdProgramName))
                                 .SingleOrDefaultAsync();
        }

        private async Task<Department> GetDepartmentsAsync(string departmentName)
        {
            return await _context.Departments
                                 .Where(foe => foe.Name.Equals(departmentName))
                                 .SingleOrDefaultAsync();
        }

        private async Task RemoveStudentTeacherRecords(int studentId)
        {
            var teacherStudentRecords = await _context.StudentTeachers.Where(st => st.StudentId == studentId).ToListAsync();
            foreach (var ts in teacherStudentRecords)
            {
                _context.StudentTeachers.Remove(ts);
            }

            await _context.SaveChangesAsync();
        }

        private void AddStudentTeacherRecordsForStudent(int[] teacherIds, int studentId)
        {
            foreach(var teacherId in teacherIds)
            {
                _context.StudentTeachers.Add(new StudentTeacher() { StudentId = studentId, TeacherId = teacherId });
            }
        }
    }
}