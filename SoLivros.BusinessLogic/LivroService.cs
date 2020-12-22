using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoLivros.BusinessLogic
{
    using SoLivros.DataAccess.EF;
    using SoLivros.Domain.DTO.Livro;
    using SoLivros.Domain.Infrastructure;
    using SoLivros.Abstraction.BusinessLogic;

    public class LivroService : ILivroService
    {
        private readonly SoLivrosContext context;
        public LivroService(SoLivrosContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ListarLivrosDTO>> ListarLivros(string filtro)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(filtro))
                {
                    return await context.Livros
                        .Select((l) => new ListarLivrosDTO()
                        {
                            Id = l.Id,
                            Nome = l.Nome,
                            Autor = l.Autor,
                            Imagem = l.Imagem
                        })
                        .ToListAsync();
                }
                else
                {
                    return await context.Livros
                        .Where((l) => l.Nome.Contains(filtro))
                        .Select((l) => new ListarLivrosDTO()
                        {
                            Id = l.Id,
                            Nome = l.Nome,
                            Autor = l.Autor,
                            Imagem = l.Imagem
                        })
                        .ToListAsync();
                }
                
            }
            catch(Exception ex)
            {
                throw new SoLivrosException("Erro ao recuperar os livros.", ex);
            }
        }

        public async Task<ListarDetalheLivroDTO> ListarDetalheLivro(int id)
        {
            try
            {
                if(id <= 0) throw new SoLivrosException("Livro não encontrado");

                return await context.Livros
                        .Where((l) => l.Id == id)
                        .Select((l) => new ListarDetalheLivroDTO()
                        {
                            Id = l.Id,
                            Nome = l.Nome,
                            Autor = l.Autor,
                            Imagem = l.Imagem,
                            Descricao = l.Descricao
                        })
                        .FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw new SoLivrosException("Erro ao recuperar livro.", ex);
            }
        }
    }
}
