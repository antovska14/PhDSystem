using System;
using System.Collections.Generic;
using System.Text;

namespace PhDSystem.Data.Models.Exams
{
    public class ExamDetails
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public string GradeType { get; set; }

        public double Grade { get; set; }

        public DateTime Date { get; set; }
    }
}
