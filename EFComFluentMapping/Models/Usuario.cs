namespace Blog.Models {
    public class Usuario {
        public Usuario(){
            Postagens = new List<Postagem>();
            Perfis = new List<Perfil>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? SenhaHash { get; set; }
        public string? Bio { get; set; }
        public string? Imagem { get; set; }
        public string? GitHub { get; set; }
        public string? Slug { get; set; }

        public List<Postagem> Postagens { get; set; }
        public List<Perfil> Perfis { get; set; }
    }
}