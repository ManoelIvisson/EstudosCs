using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models {
    [Table("Categoria")]
    public class Categoria {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        [Column("Nome", TypeName = "NVARCHAR")]
        public string? Nome { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string? Slug { get; set; }
    }
}