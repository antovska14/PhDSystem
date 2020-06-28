using System.Collections.Generic;

namespace PhDSystem.Data.Models
{
    public class StudentFileGroupDetails
    {
        public int StudentId { get; set; }

        public string FileGroup { get; set; }

        public IEnumerable<string> FileNames { get; set; }
    }
}
