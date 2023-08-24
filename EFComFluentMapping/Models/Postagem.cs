namespace Blog.Models {
    public class Postagem {
        public Postagem(){
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Resumo { get; set; }
        public string? Corpo { get; set; }
        public string? Slug { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }

        public Categoria? Categoria { get; set; }
        public Usuario? Autor { get; set; }

        public List<Tag> Tags { get; set; }
    }
}