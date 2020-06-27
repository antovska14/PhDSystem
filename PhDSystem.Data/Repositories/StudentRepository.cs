using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Models.Students;
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

        public async Task CreateStudentAsync(StudentDetails studentCreateData)
        {
            var student = new Student()
            {
                UserId = studentCreateData.UserId,
                FirstName = studentCreateData.FirstName,
                MiddleName = studentCreateData.MiddleName,
                LastName = studentCreateData.LastName,
                FormOfEducationId = studentCreateData.FormOfEducation.Id,
                DepartmentId = studentCreateData.Department.Id,
                PhdProgramId = studentCreateData.PhdProgram.Id,
                CurrentYear = studentCreateData.CurrentYear,
                SpecialtyName = studentCreateData.SpecialtyName,
                DissertationTheme = studentCreateData.DissertationTheme,
                FacultyCouncilChosenDate = studentCreateData.FacultyCouncilChosenDate,
                StartDate = studentCreateData.StartDate,
                EndDate = studentCreateData.EndDate,
            };

            // Add student and save, so the student id is created
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            // Assign teachers
            var teacherIds = studentCreateData.Teachers.Select(t => t.Id).ToArray();
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
                                            FormOfEducation = s.FormOfEducation,
                                            PhdProgram = new PhdProgram
                                            {
                                                Id = s.Department.Id,
                                                Name = s.Department.Name,
                                                ProfessionalField = new ProfessionalField
                                                {
                                                    Id = s.Department.Faculty.Id,
                                                    Name = s.Department.Faculty.Name,
                                                }
                                            },
                                            Department = new Department
                                            {
                                                Id = s.Department.Id,
                                                Name = s.Department.Name,
                                                HeadFullName = s.Department.HeadFullName,
                                                Faculty = new Faculty
                                                {
                                                    Id = s.Department.Faculty.Id,
                                                    Name = s.Department.Faculty.Name,
                                                    DeanFullName = s.Department.Faculty.DeanFullName,
                                                    University = s.Department.Faculty.University
                                                }
                                            },
                                            CurrentYear = s.CurrentYear,
                                            FacultyCouncilChosenDate = s.FacultyCouncilChosenDate.Date,
                                            Teachers = (from st in s.StudentTeachers
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

        public async Task<IEnumerable<StudentListModel>> GetStudentsAsync()
        {
            return await _context.Students.Where(s => s.IsDeleted == false)
                                          .Select(s => new StudentListModel
                                          {
                                              Id = s.Id,
                                              FirstName = s.FirstName,
                                              LastName = s.LastName,
                                              Specialty = s.SpecialtyName
                                          }).ToListAsync();
        }

        public async Task<IEnumerable<StudentListModel>> GetStudentsByTeacherAsync(int teacherId)
        {
            return await (from s in _context.Students
                          join st in _context.StudentTeachers on s.Id equals st.StudentId
                          join t in _context.Teachers on st.TeacherId equals t.Id
                          where t.Id == teacherId && !s.IsDeleted
                          select new StudentListModel
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Specialty = s.SpecialtyName
                          }).ToListAsync();
        }

        public async Task UpdateStudentAsync(int studentId, StudentDetails studentUpdateData)
        {
            var existingStudent = _context.Students.SingleOrDefault(s => s.Id == studentId);

            existingStudent.FirstName = studentUpdateData.FirstName;
            existingStudent.MiddleName = studentUpdateData.MiddleName;
            existingStudent.LastName = studentUpdateData.LastName;
            existingStudent.SpecialtyName = studentUpdateData.SpecialtyName;
            existingStudent.DissertationTheme = studentUpdateData.DissertationTheme;
            existingStudent.FacultyCouncilChosenDate = studentUpdateData.FacultyCouncilChosenDate;
            existingStudent.StartDate = studentUpdateData.StartDate;
            existingStudent.EndDate = studentUpdateData.EndDate;

            existingStudent.CurrentYear = studentUpdateData.CurrentYear;
            existingStudent.FormOfEducationId = studentUpdateData.FormOfEducation.Id;
            existingStudent.DepartmentId = studentUpdateData.Department.Id;
            existingStudent.PhdProgramId = studentUpdateData.PhdProgram.Id;

            await RemoveStudentTeacherRecords(studentId);

            var teacherIds = studentUpdateData.Teachers.Select(t => t.Id).ToArray();
            AddStudentTeacherRecordsForStudent(teacherIds, studentId);

            await _context.SaveChangesAsync();
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
            foreach (var teacherId in teacherIds)
            {
                _context.StudentTeachers.Add(new StudentTeacher() { StudentId = studentId, TeacherId = teacherId });
            }
        }
    }
}