using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

class Program {
    static void Main(string [] args) {
        Console.WriteLine("Hello, World!");

        using var contexto = new BlogDataContext();

        var postagem = new Postagem() {
            Categoria = new Categoria() {
                Nome = "Banco de Dados",
                Slug = "bd"
            },
            Autor = contexto.Usuarios.FirstOrDefault(),
            Titulo = "Modelagem Relacional",
            Resumo = "Resumindo... ",
            Corpo = "A modelagem relacional... ",
            Slug = "modelagem-relacional",
        }; 

        // contexto.Postagens.Add(postagem);

        // var postagens = await GetPostagens(contexto);
        var postagens = PegarPostagens(contexto);

        Console.WriteLine(postagens.Count);
        Console.WriteLine(postagens[0]);

        // contexto.Usuarios.Add(usuario);
        // contexto.SaveChanges();
    }
    public static async Task<List<Postagem>> GetPostagens(BlogDataContext contexto){
        return await contexto.Postagens.ToListAsync();
    }

    public static List<Postagem> PegarPostagens(BlogDataContext contexto, int skip = 0, int take = 25) {
        var postagem = contexto
            .Postagens
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToList();
        return postagem;
    }
}
