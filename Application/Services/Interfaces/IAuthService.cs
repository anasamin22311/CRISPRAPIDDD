using Domain.Models.Auth;

namespace Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(Login model);
        Task<string> AddRoleAsync(AddRole model);
    }
}
