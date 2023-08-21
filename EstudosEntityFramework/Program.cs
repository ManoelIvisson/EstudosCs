using Blog.Data;
using Blog.Models;

Console.WriteLine("Hello, World!");

using (var contexto = new BlogDataContext()) {
    // Criar(Create)
    // var tag = new Tag {Nome = "JavaSript", Slug = "javasript"};
    // contexto.Tags.Add(tag);
    // contexto.SaveChanges();

    // Atualizar(Update)
    var tag = contexto.Tags.FirstOrDefault(x => x.Id == 7)!;
    tag.Nome = "JavaScript";
    tag.Slug = "javascript";

    contexto.Update(tag);
    contexto.SaveChanges();
}