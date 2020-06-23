using PhDSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace PhDSystem.Core.Services.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string FormOfEducation { get; set; }

        public string PhdProgram { get; set; }

        public string Department { get; set; }

        public int CurrentYear { get; set; }

        public string SpecialtyName { get; set; }

        public string DissertationTheme { get; set; }

        public DateTime FacultyCouncilChosenDate { get; set; }

        public DateTime PhdStartDate { get; set; }

        public DateTime PhdEndDate { get; set; }

        public IEnumerable<TeacherDetails> Teachers { get; set; } = new List<TeacherDetails>();
    }
}
