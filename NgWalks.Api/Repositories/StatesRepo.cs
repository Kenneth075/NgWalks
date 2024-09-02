using NgWalks.Api.Models.Domain;

namespace NgWalks.Api.Repositories
{
    public static class StatesRepo
    {
        public static List<NgStatesV1> GetStates()
        {
            var states = new[]
            {
                new NgStatesV1 {Name = "Aba", Code = "Ab"},
                new NgStatesV1 {Name = "Rivers", Code = "RI"},
                new NgStatesV1 {Name = "Jos", Code = "Jo"},
                new NgStatesV1 {Name = "Abuja", Code = "Ab"}

            };

            return states.Select(x => new NgStatesV1 {Name = x.Name, Code = x.Code}).ToList();
        }
    }
}
