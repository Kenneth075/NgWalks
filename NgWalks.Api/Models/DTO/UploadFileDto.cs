using System.ComponentModel.DataAnnotations;

namespace NgWalks.Api.Models.DTO
{
    public class UploadFileDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDiscription { get; set; }
    }
}
