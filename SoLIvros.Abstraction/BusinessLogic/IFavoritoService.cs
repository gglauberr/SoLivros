using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SoLivros.Abstraction.BusinessLogic
{
    using SoLivros.Domain.DTO.Livro;
    public interface IFavoritoService
    {
        Task<bool> FavoritarLivro(ClaimsPrincipal user, int livroId);
        Task<bool> DesfavoritarLivro(ClaimsPrincipal user, int livroId);
        Task<IEnumerable<ListarLivrosDTO>> ListarLivrosFavoritados(ClaimsPrincipal user, string filtro);
    }
}
