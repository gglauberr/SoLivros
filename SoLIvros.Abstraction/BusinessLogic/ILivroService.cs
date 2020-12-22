using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoLivros.Abstraction.BusinessLogic
{
    using SoLivros.Domain.DTO.Livro;
    public interface ILivroService
    {
        Task<IEnumerable<ListarLivrosDTO>> ListarLivros(string filtro);
        Task<ListarDetalheLivroDTO> ListarDetalheLivro(int id);
    }
}
