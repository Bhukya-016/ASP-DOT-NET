using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace NZWalks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
