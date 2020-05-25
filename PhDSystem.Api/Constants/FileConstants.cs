using System;
using System.IO;

namespace PhDSystem.Api.Constants
{
    public static class FileConstants
    {
        public static string TemplateFilesDirectory = Path.Combine(Environment.CurrentDirectory, "..\\", "Templates");

        public static string IndividualPlanTemplate = "Individual_Plan.docx";

        public static string IndividualPlansResultDirectory = Path.Combine(Environment.CurrentDirectory, "..\\", "Individual Plans");
    }
}
