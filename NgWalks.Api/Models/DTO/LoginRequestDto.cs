using System.ComponentModel.DataAnnotations;

namespace NgWalks.Api.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
