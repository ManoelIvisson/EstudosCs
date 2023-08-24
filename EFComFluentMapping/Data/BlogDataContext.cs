using Microsoft.EntityFrameworkCore;

namespace Blog.Data {
    public class BlogDataContext : DbContext {

        protected override void OnConfiguring(DbContextOptionsBuilder opcoes)
        => opcoes.UseSqlServer(@"");

    }
}