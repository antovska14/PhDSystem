using System;
using System.Collections.Generic;
using System.Text;

namespace PhDSystem.Core.Services.Helpers
{
    public static class ExamHelper
    {
        public static string GetGradeType(double grade)
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
