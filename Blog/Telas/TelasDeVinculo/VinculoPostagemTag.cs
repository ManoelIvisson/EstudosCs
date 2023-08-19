using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;
using Dapper;

namespace Blog.Telas.TelasDevinculo {
   public static class VinculoPostagemTag {
        public static void VuncularPostagemTag(int postagemId = 0, int tagId = 0) {
            Console.Clear();

            if (postagemId == 0) {
                Console.WriteLine("Digite o id da postagem: ");
                postagemId = short.Parse(Console.ReadLine()!);
            }

            if (tagId == 0) {
                tagId = Verificacao.CarregarTelaViaSlug("Tag");
            } 

            var sql = "INSERT INTO [PostagemTag] VALUES (@PostagemId, @TagId)";
            var repositorio = new Repositorio<PostagemTag>();
            
            var vinculo = BancoDeDados.Conexao.Query<PostagemTag>(sql, new {
                PostagemId = postagemId,
                TagId = tagId
            });

            foreach (var item in vinculo) {
                repositorio.Criar(item);
            }

            Console.WriteLine("Vínculo criado com sucesso");
            Console.ReadKey();
            Menu.Inicio();
        }
   }
}