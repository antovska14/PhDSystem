using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models.Exams;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly PhdSystemDbContext _context;

        public ExamRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExam(int examId)
        {
            var exam = await _context.Exams.Where(e => e.Id.Equals(examId)).SingleOrDefaultAsync();
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamsYearDetails>> GetExams(int studentId)
        {
            var examsDictionary = new Dictionary<int, IList<ExamDetails>>();

            var exams = await _context.Exams.Where(e => e.StudentId == studentId).Select(x => new ExamDetails 
            { 
                Id = x.Id,
                Name = x.Name,
                Date = x.Date,
                Grade = x.Grade
            }).ToListAsync();

            foreach (var exam in exams)
            {
                string gradeType = GetGradeType(exam.Grade);
                exam.GradeType = gradeType;
                if (examsDictionary.TryGetValue(exam.Year, out var examsByYear))
                {
                    examsByYear.Add(exam);
                }
                else
                {
                    examsDictionary.Add(exam.Year, new List<ExamDetails> { exam });
                }
            }

            var examsList = new List<ExamsYearDetails>();

            foreach (var keyValuePair in examsDictionary)
            {
                examsList.Add(new ExamsYearDetails
                {
                    StudentId = studentId,
                    Year = keyValuePair.Key,
                    Exams = keyValuePair.Value
                });
            }

            return examsList;
        }

        private string GetGradeType(double grade)
        {
            string gradeType;

            if(grade < 2.5)
            {
                gradeType = "слаб";
            }
            else if(grade < 3.5)
            {
                gradeType = "среден";
            }
            else if (grade < 4.5)
            {
                gradeType = "добър";
            }
            else if (grade < 5.5)
            {
                gradeType = "мн. добър";
            }
            else
            {
                gradeType = "отличен";
            }

            return gradeType;
        }
    }
}
