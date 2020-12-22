using System.Collections.Generic;

namespace SoLivros.Domain.DTO.Livro
{
    public class ListarDetalheLivroResponse : BaseResponse<ListarDetalheLivroDTO> { }
    public class ListarLivrosResponse : BaseResponse<IEnumerable<ListarLivrosDTO>> { }
}
