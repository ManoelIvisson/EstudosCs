using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Telas.TelasDeTag {
    public static class TelaListarTags {
        public static void ListarTags(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Lista de Tags =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Tag>();
            var tags = repositorio.Get();
            foreach (var tag in tags) {
                var sql = @"SELECT [TagId] FROM [PostagemTag] WHERE [TagId] = @Id";
                var quantidadePostagens = BancoDeDados.Conexao.Query<PostagemTag>(sql, new {
                    Id = tag.Id
                }).Count();

                Console.WriteLine($" {tag.Id} - {tag.Nome} - {tag.Slug}");
                Console.WriteLine($" Postagens Relacionadas: {quantidadePostagens}");
            }
            Console.ReadKey();
        }
    }
}
