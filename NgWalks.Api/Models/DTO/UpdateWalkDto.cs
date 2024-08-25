using NgWalks.Api.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NgWalks.Api.Models.DTO
{
    public class UpdateWalkDto
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public required string Description { get; set; }
        [Required]
        [Range(0, 50)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
