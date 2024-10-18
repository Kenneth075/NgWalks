namespace NgWalks.Api.Models.Domain
{
    public class Difficulty
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Walk> Walks { get; set; }
    }
}
