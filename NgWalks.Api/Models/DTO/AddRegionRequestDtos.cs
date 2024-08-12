namespace NgWalks.Api.Models.DTO
{
    public class AddRegionRequestDtos
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
