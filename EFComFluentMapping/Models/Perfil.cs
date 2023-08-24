namespace Blog.Models {
    public class Perfil {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Slug { get; set; }

        public List<Usuario>? Usuarios { get; set; }
    }
}