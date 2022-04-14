using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IJwtService
    {
        string GenerateToken(UserViewModel user);
    }
}
