using Microsoft.AspNetCore.Http;
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
        public async Task<FileModel> GetFileAsync(string[] folders, string fileName)
        {
            string foldersPath = Path.Combine(folders);
            string filePath = Path.Combine(Environment.CurrentDirectory, FileConstants.RootFolder, foldersPath, fileName);
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

        public async Task StoreFileAsync(string[] folders, IFormFile file)
        {
            string foldersPath = Path.Combine(folders);
            string filePath = Path.Combine(Environment.CurrentDirectory, FileConstants.RootFolder, foldersPath, file.FileName);
            using (var fileStream = File.Create(filePath))
            {
                await file.CopyToAsync(fileStream);
            }
        }
    }
}

