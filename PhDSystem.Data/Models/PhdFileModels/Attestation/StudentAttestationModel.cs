using System;
using System.Collections.Generic;
using System.Text;

namespace PhDSystem.Data.Models.PhdFileModels.Attestation
{
    public class StudentAttestationModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FormOfEducation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
