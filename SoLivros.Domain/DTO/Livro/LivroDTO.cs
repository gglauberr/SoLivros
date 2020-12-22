namespace SoLivros.Domain.DTO.Livro
{
    public class ListarDetalheLivroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
    }

    public class ListarLivrosDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Imagem { get; set; }
    }
}
