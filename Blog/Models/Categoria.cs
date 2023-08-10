using Dapper.Contrib.Extensions;

namespace Blog.Models {
    [Table("[Categoria]")]
    public class Categoria {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Slug { get; set; }
    }
}