using Microsoft.AspNetCore.Identity;

namespace NgWalks.Api.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken (IdentityUser user, List<string> roles);
    }
}
