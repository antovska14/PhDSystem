using MimeKit;
using PhDSystem.Core.Constants;
using PhDSystem.Core.Managers.Interfaces;
using PhDSystem.Core.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PhDSystem.Api.Managers
{
    public class FileManager : IFileManager
    {
        public async Task<FileModel> GetFileAsync(string bucketName, string folderName, string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, FileConstants.RootFolder, bucketName, folderName, fileName);
            using (var fileStream = File.OpenRead(filePath))
            {
                MemoryStream fileMemoryStream = new MemoryStream();
                await fileStream.CopyToAsync(fileMemoryStream);
                fileMemoryStream.Position = 0;

                return new FileModel
                {
                    FileName = fileName,
                    FileContent = fileMemoryStream,
                    ContentType = MimeTypes.GetMimeType(fileName)
                };
            }
        }
    }
}

