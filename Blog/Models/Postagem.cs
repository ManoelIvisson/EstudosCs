using Dapper.Contrib.Extensions;

namespace Blog.Models {
    [Table("Postagem")]
    
    public class Postagem {
        public Postagem() {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public int AutorId { get; set; }
        public string? Titulo { get; set; }
        public string? Resumo { get; set; }
        public string? Corpo { get; set; }
        public string? Slug { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        [Write(false)]
        public List<Tag> Tags { get; set; }
    }
}