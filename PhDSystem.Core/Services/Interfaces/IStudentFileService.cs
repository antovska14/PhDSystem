using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IStudentFileService
    {
        Task UploadFile(string fileName);
    }
}
