using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace SoLivros.API.Controllers
{
    using SoLivros.Abstraction.BusinessLogic;
    using SoLivros.Domain.DTO;
    using SoLivros.Domain.DTO.Livro;

    public class FavoritoController : BaseController
    {
        private readonly IFavoritoService favoritoService;
        public FavoritoController(IFavoritoService favoritoService)
        {
            this.favoritoService = favoritoService ?? throw new ArgumentNullException(nameof(favoritoService));
        }

        [HttpGet("{livroId}")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> FavoritarLivro(int livroId)
        {
            var response = new BaseResponse<string>();
            try
            {
                response.Success = await favoritoService.FavoritarLivro(User, livroId);
                response.Message = response.Success
                                   ? "Livro favoritado com sucesso."
                                   : "Erro ao favoritar livro";
            }
            catch(Exception ex)
            {
                response.MontaErro(ex);
            }
            return Result(response);
        }

        [HttpGet("{livroId}")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> DesfavoritarLivro(int livroId)
        {
            var response = new BaseResponse<string>();
            try
            {
                response.Success = await favoritoService.DesfavoritarLivro(User, livroId);
                response.Message = response.Success
                                   ? "Livro desfavoritado com sucesso."
                                   : "Erro ao desfavoritar livro";
            }
            catch (Exception ex)
            {
                response.MontaErro(ex);
            }
            return Result(response);
        }

        [HttpGet]
        [ProducesDefaultResponseType(typeof(ListarLivrosResponse))]
        public async Task<IActionResult> ListarLivrosFavoritados(string filtro)
        {
            var response = new ListarLivrosResponse();
            try
            {
                response.Data = await favoritoService.ListarLivrosFavoritados(User, filtro);
                response.Success = true;
                response.Message = "Livros recuperados com sucesso.";
            }
            catch (Exception ex)
            {
                response.MontaErro(ex);
            }
            return Result(response);
        }
    }
}
