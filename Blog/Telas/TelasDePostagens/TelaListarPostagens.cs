using Blog.Models;
using Blog.Repositories;

namespace Blog.Telas.TelasDePostagem {
    public static class TelaListarPostagem {
        public static void ListarPostagens(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Lista de Postagens =-=-=-=-=-=-=-=");
            var repositorio = new PostagemRepositorio();
            var reposCategoria = new Repositorio<Categoria>();
            var reposUsuario = new Repositorio<Usuario>();
            var postagens = repositorio.LerComTags();

            foreach (var postagem in postagens) {
                var categoria = reposCategoria.Get(postagem.CategoriaId);
                var usuario = reposUsuario.Get(postagem.AutorId);

                Console.WriteLine($" Postagem: {postagem.Id} - Categoria: {categoria.Nome}");
                Console.Write(" Tags: ");
                foreach (var item in postagem.Tags){
                    if (item != postagem.Tags.Last()) {
                        Console.Write($"{item.Nome}, ");
                    } else {
                        Console.Write($"{item.Nome}");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("=-=-=-=-=-=-= Título =-=-=-=-=-=-=");
                Console.WriteLine($"{postagem.Titulo}");
                Console.WriteLine($"Autor(es): {usuario.Nome}");
                Console.WriteLine("");
                Console.WriteLine("=-=-=-=-=-=-= Resumo =-=-=-=-=-=-=");
                Console.WriteLine($"{postagem.Resumo}");
                Console.WriteLine("");
                Console.WriteLine($"  {postagem.Corpo}");
            }
            Console.ReadKey();
        }
    }
}