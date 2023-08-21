using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data {
    public class BlogDataContext : DbContext {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        // public DbSet<PostagemTag>? PostagemTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        // public DbSet<UsuarioPerfil>? UsuarioPerfis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opcoes)
        => opcoes.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Blog;Integrated Security=SSPI;TrustServerCertificate=True");
        
    }
}