using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;
using Dapper;

namespace Blog.Telas.TelasDePostagem {
    public static class TelaDeletarPostagem {
        public static void DeletarPostagem(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Deletar Postagem =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Postagem>();

            Console.WriteLine("Digite o id da postagem: ");
            var id = int.Parse(Console.ReadLine()!);
            var postagem = repositorio.Get(id);

            try {
                repositorio.Deletar(id);
                DeletarTagsVinculadas(id);
                Console.WriteLine("Usuario Deletado com sucesso");
            } catch (Exception ex) {
                Console.WriteLine("Não foi possível deletar o usuário");
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        public static void DeletarTagsVinculadas(int id){
            var sql = @"DELETE FROM [PostagemTag] WHERE [PostagemId] = @Id";
            var repositorio = new Repositorio<PostagemTag>();

            BancoDeDados.Conexao.Query<PostagemTag>(sql, new {
                Id = id
            });
        }
    }
}