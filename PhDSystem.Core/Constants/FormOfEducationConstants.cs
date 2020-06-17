using System;
using System.Collections.Generic;
using System.Text;

namespace PhDSystem.Core.Constants
{
    public static class FormOfEducationConstants
    {
        public static Dictionary<string, string> FormOfEducationBgToEn = new Dictionary<string, string>() 
        { 
            {"задочна", "Distance"},
            {"редовна", "FullTime"},
            {"свободна", "Free"},
        };
    }
}
