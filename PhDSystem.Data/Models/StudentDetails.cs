using PhDSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

        public int CurrentYear { get; set; }

        public string SpecialtyName { get; set; }

        public DateTime FacultyCouncilChosenDate { get; set; }

        public int TitleId { get; set; }

        public int DegreeId { get; set; }


        public IEnumerable<Teacher> Supervisors { get; set; }
    }
}
