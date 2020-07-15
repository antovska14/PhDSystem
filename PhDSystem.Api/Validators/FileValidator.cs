using Microsoft.AspNetCore.Http;
using PhDSystem.Core.Constants;
using System.IO;

namespace PhDSystem.Api.Validators
{
    public static class FileValidator
    {
        public static bool IsValid(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);

            if (!IsExtensionAllowed(extension))
            {
                return false;
            }

            if (ExceedMaxSize(file.Length))
            {
                return false;
            }

            return true;
        }

        private static bool IsExtensionAllowed(string extension)
        {
            bool isAllowed = true;

            if (FileConstants.BadFileExtensions.Contains(extension.ToLowerInvariant()))
            {
                isAllowed = false;
            }

            return isAllowed;
        }

        private static bool ExceedMaxSize(long fileSize)
        {
            return fileSize > FileConstants.MaxFileSize;
        }
    }
}
