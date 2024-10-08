﻿using NgWalks.Api.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NgWalks.Api.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public required string Description { get; set; }
        [Range(0,50)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
