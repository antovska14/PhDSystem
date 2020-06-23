using System;

namespace PhDSystem.Data.Models.PhdFileModels.Attestation
{
    public class ExamAttestationModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string GradeType { get; set; }
        public double Grade { get; set; }
    }
}