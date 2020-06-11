using System.IO;

namespace PhDSystem.Core.Models
{
    public class FileModel
    {
        public Stream FileContent { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
