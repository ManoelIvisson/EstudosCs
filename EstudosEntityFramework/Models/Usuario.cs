using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models {
    [Table("Usuario")]
    public class Usuario {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? SenhaHash { get; set; }
        public string? Bio { get; set; }
        public string? Imagem { get; set; }
        public string? Slug { get; set; }
    }
}