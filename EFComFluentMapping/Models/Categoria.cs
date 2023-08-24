namespace Blog.Models {
    public class Categoria {
        public Categoria(){
            postagens = new List<Postagem>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Slug { get; set; }

        public List<Postagem> postagens { get; set; }
    }
}