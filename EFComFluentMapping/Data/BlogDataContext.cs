using Blog.Data.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data {
    public class BlogDataContext : DbContext {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opcoes)
        => opcoes.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Blog;Integrated Security=SSPI;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder){
           modelBuilder.ApplyConfiguration(new CategoriaMap());
           modelBuilder.ApplyConfiguration(new UsuarioMap());
           modelBuilder.ApplyConfiguration(new PostagemMap());
        }
    }
}