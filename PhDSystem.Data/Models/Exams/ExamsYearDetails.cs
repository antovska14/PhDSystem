using PhDSystem.Data.Entities;
using System.Collections.Generic;

namespace PhDSystem.Data.Models.Exams
{
    public class ExamsYearDetails
    {
        public int StudentId { get; set; }

        public int Year { get; set; }

        public IEnumerable<ExamDetails> Exams { get; set; }
    }
}
