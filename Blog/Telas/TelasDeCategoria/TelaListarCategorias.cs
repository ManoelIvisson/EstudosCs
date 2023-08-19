using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;
using Dapper;

namespace Blog.Telas.TelasDeCategoria {
    public static class TelaListarCategorias {
        public static void ListarCategorias(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Lista de Categorias =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Categoria>();
            var categorias = repositorio.Get();

            foreach (var categoria in categorias) {
                var sql = @"SELECT [Id] FROM [Postagem] WHERE [CategoriaId] = @Id";
                var quantidadePostagens = BancoDeDados.Conexao.Query<Categoria>(sql, new {
                    Id = categoria.Id
                }).Count();

                Console.WriteLine($" {categoria.Id} - {categoria.Nome} - {categoria.Slug}");
                Console.WriteLine($"      Postagens relacionadas: {quantidadePostagens}");
            }
            Console.ReadKey();
        }

        public static void ListarPostagensDeUmaCategoria(){
            Console.Clear();
            var repositorio = new Repositorio<Categoria>();
            var categoria = repositorio.Get(Verificacao.CarregarTelaViaSlug("Categoria"));

            var sql = @"SELECT [Id], [Titulo], [Resumo] FROM [Postagem] WHERE [CategoriaId] = @Id";
            var postagens = BancoDeDados.Conexao.Query<Postagem>(sql, new {
                Id = categoria.Id
            });

            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Lista de Postagens por Categoria =-=-=-=-=-=-=-=");
            Console.WriteLine($"Postagens da categoria: {categoria.Nome}");
            foreach (var postagem in postagens) {
                Console.WriteLine($" {postagem.Id} - {postagem.Titulo}");
            }
            Console.ReadKey();
        }
    }
}
