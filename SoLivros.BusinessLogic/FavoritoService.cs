using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SoLivros.BusinessLogic
{
    using SoLivros.Abstraction.BusinessLogic;
    using SoLivros.CrossCutting.Extensions;
    using SoLivros.DataAccess.EF;
    using SoLivros.Domain.DTO.Livro;
    using SoLivros.Domain.Infrastructure;
    using SoLivros.Domain.Models;

    public class FavoritoService : IFavoritoService
    {
        private readonly SoLivrosContext context;
        public FavoritoService(SoLivrosContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> FavoritarLivro(ClaimsPrincipal user, int livroId)
        {
            try
            {
                if(livroId <= 0) throw new SoLivrosException("O livro não foi informado");

                var livro = await context.Livros.FindAsync(livroId);

                if(livro is null) throw new SoLivrosException("O livro não encontrado");

                var email = user.GetEmail();

                context.Favoritos.Add(new Favorito()
                {
                    Email = email,
                    LivroId = livroId
                });

                return (await context.SaveChangesAsync() > 0);

            }
            catch(Exception ex)
            {
                throw new SoLivrosException("Erro ao favoritar livro.", ex);
            }
        }

        public async Task<bool> DesfavoritarLivro(ClaimsPrincipal user, int livroId)
        {
            try
            {
                if (livroId <= 0) throw new SoLivrosException("O livro não foi informado");

                var livro = await context.Livros.FindAsync(livroId);

                if (livro is null) throw new SoLivrosException("O livro não encontrado");

                var email = user.GetEmail();

                var favorito = await context.Favoritos
                    .Where((f) => f.LivroId == livroId && f.Email.Equals(email))
                    .FirstOrDefaultAsync();

                if(favorito is null) throw new SoLivrosException("O livro não está marcado como favorito");

                context.Remove(favorito);

                return (await context.SaveChangesAsync() > 0);

            }
            catch (Exception ex)
            {
                throw new SoLivrosException("Erro ao favoritar livro.", ex);
            }
        }

        public async Task<IEnumerable<ListarLivrosDTO>> ListarLivrosFavoritados(ClaimsPrincipal user, string filtro)
        {
            try
            {
                var email = user.GetEmail();

                return await context.Favoritos
                        .Where((f)
                             => !string.IsNullOrWhiteSpace(filtro)
                                 ? f.Livro.Nome.Contains(filtro)
                                 : true
                             && f.Email.Equals(email))
                        .Select((f) => new ListarLivrosDTO()
                        {
                            Id = f.Livro.Id,
                            Nome = f.Livro.Nome,
                            Autor = f.Livro.Autor,
                            Imagem = f.Livro.Imagem
                        })
                        .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new SoLivrosException("Erro ao recuperar livros", ex);
            }
        }
    }
}
