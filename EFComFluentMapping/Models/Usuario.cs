namespace Blog.Models {
    public class Usuario {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? SenhaHash { get; set; }
        public string? Bio { get; set; }
        public string? Imagem { get; set; }
        public string? Slug { get; set; }
    }
}