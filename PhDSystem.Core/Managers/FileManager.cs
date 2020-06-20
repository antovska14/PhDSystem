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
            string foldersPath = GetFullFoldersPath(folders);
            string filePath = Path.Combine(foldersPath, fileName);
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
            string foldersPath = GetFullFoldersPath(folders);
            Directory.CreateDirectory(foldersPath);
            string filePath = Path.Combine(foldersPath, file.FileName);
            using (var fileStream = File.Create(filePath))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        public void DeleteFile(string[] folders, string fileName)
        {
            string foldersPath = Path.Combine(folders);
            string fullFoldersPath = Path.Combine(Environment.CurrentDirectory, FileConstants.RootFolder, foldersPath);
            string filePath = Path.Combine(fullFoldersPath, fileName);
            File.Delete(filePath);
        }

        private string GetFullFoldersPath(string[] folders)
        {
            string foldersPath = Path.Combine(folders);
            return Path.Combine(Environment.CurrentDirectory, FileConstants.RootFolder, foldersPath);
        }
    }
}

