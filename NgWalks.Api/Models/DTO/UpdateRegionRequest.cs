namespace NgWalks.Api.Models.DTO
{
    public class UpdateRegionRequest
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
