using System;
using System.Collections.Generic;
using System.Text;

namespace PhDSystem.Data.Models
{
    public class StudentFileDetails
    {
        public int StudentId { get; set; }

        public string FileGroup { get; set; }

        public IEnumerable<string> FileNames { get; set; }
    }
}
