using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoLivros.Domain.Models
{
    public class Favorito
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Email { get; set; }

        [Required, ForeignKey(nameof(Livro))]
        public int LivroId { get; set; }

        public virtual Livro Livro { get; set; }
    }
}
