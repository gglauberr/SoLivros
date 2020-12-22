using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoLivros.Domain.Models
{
    public class Livro
    {
        public Livro()
        {
            Favoritos = new HashSet<Favorito>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Nome { get; set; }

        [Required, MaxLength(250)]
        public string Autor { get; set; }

        [Required, MaxLength(500)]
        public string Imagem { get; set; }

        [Required, MaxLength(5000)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Favorito.Livro))]
        public virtual ICollection<Favorito> Favoritos { get; set; } 
    }
}
