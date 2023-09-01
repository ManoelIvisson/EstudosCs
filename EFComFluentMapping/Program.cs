using Blog.Data;
using Blog.Models;

Console.WriteLine("Hello, World!");

var usuario = new Usuario() {
    Nome = "Zeus",
    Email = "zeus@exemplo.com",
    SenhaHash = "raio",
    Bio = "Rei do Olimpuus",
    Imagem = "https://...",
    GitHub = "zeus",
    Slug = "zeus"
}; 

using var contexto = new BlogDataContext();

contexto.Usuarios.Add(usuario);
contexto.SaveChanges();