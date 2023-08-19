using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;
using Dapper;

namespace Blog.Telas.TelasDeTag {
    public static class TelaDeletarTag {
        public static void DeletarTag(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Deletar Tag =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Tag>();

            int id = Verificacao.CarregarTelaViaSlug("Tag");
            if (id == 0) {
                Console.WriteLine("a tag não foi encontrada, por favor tente novamente");
                Console.ReadKey();
                DeletarTag();
            }

            try {
                repositorio.Deletar(id);
                DeletarPostagensVinculadas(id);
                Console.WriteLine("Tag Deletada com sucesso");
            } catch (Exception ex) {
                Console.WriteLine("Não foi possível deletar a tag");
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        public static void DeletarPostagensVinculadas(int id){
        var sql = @"DELETE FROM [PostagemTag] WHERE [TagId] = @Id";

        BancoDeDados.Conexao.Query<PostagemTag>(sql, new {
            Id = id
        });
    }
    }
}