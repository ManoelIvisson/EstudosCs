using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models {
    [Table("Postagem")]
    public class Postagem {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Resumo { get; set; }
        public string? Corpo { get; set; }
        public string? Slug { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [ForeignKey("AutorId")]
        public int AutorId { get; set; }
        public Usuario? Autor { get; set; }
    }
}