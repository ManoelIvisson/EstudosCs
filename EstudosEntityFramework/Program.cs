using Blog.Data;
using Blog.Models;

Console.WriteLine("Hello, World!");

using (var contexto = new BlogDataContext()) {
    var tag = new Tag {Nome = "JavaSript", Slug = "javasript"};
    contexto.Tags.Add(tag);
    contexto.SaveChanges();
}