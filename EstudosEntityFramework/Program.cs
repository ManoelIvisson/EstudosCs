using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using var contexto = new BlogDataContext();

var usuario = new Usuario {
  Nome = "Manoel do Pastel",
  Email = "manoelpastel@exemplo.com",
  SenhaHash = "senha",
  Bio = "Gosto de Pastel",
  Imagem = "https://...",
  Slug = "manoel-do-pastel"  
};

var categoria = new Categoria {
    Nome = "Backend",
    Slug = "backend"
};

var postagem = new Postagem {
    Categoria = categoria,
    Autor = usuario,
    Titulo = "Backend básico",
    Resumo = "Resumindo... ",
    Corpo = "Opa",
    Slug = "backend-basico",
    DataCriacao = DateTime.Now,
    DataUltimaAtualizacao = DateTime.Now
};

contexto.Postagens.Add(postagem);
contexto.SaveChanges();

// using (var contexto = new BlogDataContext()) {
    // Criar(Create)
    // var tag = new Tag {Nome = "JavaSript", Slug = "javasript"};
    // contexto.Tags.Add(tag);
    // contexto.SaveChanges();

    // Atualizar(Update)
    // var tag = contexto.Tags.FirstOrDefault(x => x.Id == 7)!;
    // tag.Nome = "JavaScript";
    // tag.Slug = "javascript";

    // contexto.Update(tag);
    // contexto.SaveChanges();

    // Deletar(Delete)
    // var tag = contexto.Tags.FirstOrDefault(x => x.Id == 7)!;

    // contexto.Remove(tag);
    // contexto.SaveChanges();

    // Ler(Read)
    // var tags = contexto.Tags.AsNoTracking().Where(x => x.Nome.Contains("Ja")).ToList();
    
    // foreach (var item in tags) {
    //     Console.WriteLine(item?.Nome);
    // }
// }