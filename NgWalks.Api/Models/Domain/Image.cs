using System.ComponentModel.DataAnnotations.Schema;

namespace NgWalks.Api.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDiscription { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeInByte { get; set; }
        public string FilePath { get; set; }
    }
}
