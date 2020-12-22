using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SoLivros.DataAccess.EF
{
    using SoLivros.Domain.Models;

    public class SoLivrosContext : IdentityDbContext<User>
    {
        public SoLivrosContext(DbContextOptions<SoLivrosContext> options) : base(options)
        {

        }

        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
    }
}
