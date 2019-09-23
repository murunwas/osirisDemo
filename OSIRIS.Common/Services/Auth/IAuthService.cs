using OSIRIS.Common.Responses;
using System.Threading.Tasks;

namespace OSIRIS.Common.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);

        Task<AuthenticationResult> LoginAsync(string email, string password);

        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);

    }
}
