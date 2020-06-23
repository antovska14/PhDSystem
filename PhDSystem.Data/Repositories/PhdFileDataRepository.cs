using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Models.PhdFileModels.Annotation;
using PhDSystem.Data.Models.PhdFileModels.Attestation;
using PhDSystem.Data.Models.PhdFileModels.IndividualPlan;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class PhdFileDataRepository : IPhdFileDataRepository
    {
        private readonly PhdSystemDbContext _context;

        public PhdFileDataRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task<AnnotationModel> GetAnnotationData(int studentId)
        {
            var annotation = await (from s in _context.Students
                                    join d in _context.Departments on s.DepartmentId equals d.Id
                                    join f in _context.Faculties on d.FacultyId equals f.Id
                                    join u in _context.Universities on f.UniversityId equals u.Id
                                    where s.Id == studentId && s.IsDeleted == false
                                    select new AnnotationModel
                                    {
                                        UniversityName = u.Name,
                                        Faculty = new FacultyAnnotationModel { Name = f.Name, DeanFullName = f.DeanFullName },
                                        DepartmentName = d.Name,
                                        DissertationTheme = s.DissertationTheme,
                                        Student = new StudentAnnotationModel { FirstName = s.FirstName, MiddleName = s.MiddleName, LastName = s.LastName },
                                        Teachers = (from st in _context.StudentTeachers
                                                    join t in _context.Teachers on st.TeacherId equals t.Id
                                                    select new TeacherAnnotationModel 
                                                    { 
                                                        FirstName = t.FirstName, 
                                                        LastName = t.LastName,
                                                        Degree = t.Degree,
                                                        Title = t.Title
                                                    }).ToList()
                                    }).SingleOrDefaultAsync();

            return annotation;
        }

        public async Task<AttestationModel> GetAttestationData(int studentId, int year)
        {
            var attestation = await (from s in _context.Students
                                    join d in _context.Departments on s.DepartmentId equals d.Id
                                    join f in _context.Faculties on d.FacultyId equals f.Id
                                    join u in _context.Universities on f.UniversityId equals u.Id
                                    where s.Id == studentId && s.IsDeleted == false
                                    select new AttestationModel
                                    {
                                        UniversityName = u.Name,
                                        FacultyName = f.Name,
                                        DepartmentName = d.Name,
                                        DissertationTheme = s.DissertationTheme,
                                        Student = new StudentAttestationModel 
                                        { 
                                            FirstName = s.FirstName, 
                                            MiddleName = s.MiddleName, 
                                            LastName = s.LastName,
                                            FormOfEducation = s.FormOfEducation.Name,
                                            StartDate = s.StartDate,
                                            EndDate = s.EndDate
                                        },
                                        Teachers = (from st in _context.StudentTeachers
                                                    join t in _context.Teachers on st.TeacherId equals t.Id
                                                    where st.StudentId == studentId
                                                    select new TeacherAttestationModel
                                                    {
                                                        FirstName = t.FirstName,
                                                        LastName = t.LastName,
                                                        Degree = t.Degree,
                                                        Title = t.Title,
                                                    }).ToList(),
                                        Exams = (from e in _context.Exams
                                                 where e.StudentId == studentId && e.Year == year
                                                 select new ExamAttestationModel 
                                                 { 
                                                    Name = e.Name,
                                                    Date = e.Date,
                                                    Grade = e.Grade,
                                                    GradeType = e.Grade > 2 ? "положителна" : "отрицателна"
                                                 }).ToList()
                                    }).SingleOrDefaultAsync();

            return attestation;
        }

        public async Task<IndividualPlanModel> GetIndividualPlanData(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
