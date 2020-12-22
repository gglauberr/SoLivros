using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace SoLivros.API.Controllers
{
    using SoLivros.Domain.DTO;
    using SoLivros.Domain.DTO.Livro;
    using SoLivros.Abstraction.BusinessLogic;

    public class LivroController : BaseController
    {
        private readonly ILivroService livroService;
        public LivroController(ILivroService livroService)
        {
            this.livroService = livroService ?? throw new ArgumentNullException(nameof(livroService));
        }

        [HttpGet]
        [ProducesDefaultResponseType(typeof(ListarLivrosResponse))]
        public async Task<IActionResult> ListarLivros()
        {
            var filtro = Request.Query["filtro"].ToString();
            var response = new ListarLivrosResponse();
            try
            {
                response.Data = await livroService.ListarLivros(filtro);
                response.Success = true;
                response.Message = "Livros recuperados com sucesso.";
            }
            catch(Exception ex)
            {
                response.MontaErro(ex);
            }
            return Result(response);
        }

        [HttpGet("{id}")]
        [ProducesDefaultResponseType(typeof(ListarDetalheLivroResponse))]
        public async Task<IActionResult> ListarDetalheLivro(int id)
        {
            var response = new ListarDetalheLivroResponse();
            try
            {
                response.Data = await livroService.ListarDetalheLivro(id);
                response.Success = true;
                response.Message = "Livro recuperado com sucesso.";
            }
            catch (Exception ex)
            {
                response.MontaErro(ex);
            }
            return Result(response);
        }
    }
}
