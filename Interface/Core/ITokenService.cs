using Core.Entities.Identity;

namespace Interface.Core
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}