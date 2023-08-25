using Blog.Data;
using Blog.Models;

Console.WriteLine("Hello, World!");

using var contexto = new BlogDataContext();

// var usuario = new Usuario() {
//     Nome = "Chaves do 8",
//     Email = "elchavo@exemplo.com",
//     SenhaHash = "comida",
//     Bio = "Eu amo um sanduíche de presentu S2",
//     Imagem = "https://...",
//     Slug = "chaves"
// };

// contexto.Usuarios.Add(usuario);
// contexto.SaveChanges();

var usuario = contexto.Usuarios.Where(x => x.Slug == "chaves").ToList();

var postagem = new Postagem() {
    Autor = usuario.FirstOrDefault(),
    Categoria = new Categoria() {
        Nome = "Alimentos",
        Slug = "alimentos"
    },
    Titulo = "A procura por sandíches",
    Resumo = "Bem, começando do começo... ",
    Corpo = "O foco é... ",
    Slug = "sanduiches"
};

contexto.Postagens.Add(postagem);
contexto.SaveChanges();