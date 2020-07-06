using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models.Exams;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<IEnumerable<ExamsYearDetails>> GetExams(int studentId)
        {
            IEnumerable<ExamDetails> exams = await _examRepository.GetExams(studentId);

            var examsDictionary = new Dictionary<int, IList<ExamDetails>>();
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

            if (grade < 2.5)
            {
                gradeType = "слаб";
            }
            else if (grade < 3.5)
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
