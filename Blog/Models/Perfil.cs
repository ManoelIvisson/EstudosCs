using Dapper.Contrib.Extensions;

namespace Blog.Models {
    [Table("[Perfil]")]
    public class Perfil {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Slug { get; set; }
    }
}