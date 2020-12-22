using System.Threading.Tasks;

namespace SoLivros.Abstraction.BusinessLogic
{
    using SoLivros.Domain.DTO.User;
    public interface IUserService
    {
        Task<TokenDTO> CriarConta(RegisterUserRequest req);
        Task<TokenDTO> FazerLogin(LoginRequest req);
    }
}
