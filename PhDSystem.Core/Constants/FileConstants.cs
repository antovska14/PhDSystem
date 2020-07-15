using Org.BouncyCastle.Utilities.Collections;
using System.Collections.Generic;

namespace PhDSystem.Core.Constants
{
    public static class FileConstants
    {
        public static string RootFolder = "Resources";

        public static string TemplatesFolder = "Templates";

        public static string StudentFilesFolder = "StudentFiles";

        public static string IndividualPlanWordFileName = "IndividualPlan.docx";

        public static string AttestationWordFileName = "Attestation.docx";

        public static string AnnotationWordFileName = "Annotation.docx";

        public static string GeneralFolder = "General";

        public static string WordFileContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document; charset=UTF-8";

        public static HashSet<string> BadFileExtensions = new HashSet<string> { ".exe" };

        /// <summary>
        /// 5MB in bits (5 * 1024 * 1024)
        /// </summary>
        public static long MaxFileSize = 5242880;
    }
}
