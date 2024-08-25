using System.ComponentModel.DataAnnotations;

namespace NgWalks.Api.Models.DTO
{
    public class AddRegionRequestDtos
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Region code most have a maximum of 3 characters.")]
        [MinLength(3, ErrorMessage = "Region code most have a minimum of 3 characters.")]
        public required string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
