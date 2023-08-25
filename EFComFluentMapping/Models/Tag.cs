namespace Blog.Models {
    public class Tag {
        public Tag(){
            Postagens = new List<Postagem>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Slug { get; set; }

        public List<Postagem> Postagens { get; set; }
    }
}