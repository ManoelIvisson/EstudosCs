using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;
using Dapper;

namespace Blog.Telas.TelasDePerfil {
    public static class TelaDeletarPerfil {
        public static void DeletarPerfil(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Deletar Perfil =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Perfil>();

            int id = Verificacao.CarregarTelaViaSlug("Perfil");
            if (id == 0) {
                Console.WriteLine("O perfil não foi encontrado, por favor tente novamente");
                Console.ReadKey();
                DeletarPerfil();
            }

            try {
                repositorio.Deletar(id);
                DeletarUsuariosVinculados(id);
                Console.WriteLine("Perfil Deletado com sucesso");
            } catch (Exception ex) {
                Console.WriteLine("Não foi possível deletar o Perfil");
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        public static void DeletarUsuariosVinculados(int id){
            var sql = @"DELETE FROM [UsuarioPerfil] WHERE [PerfilId] = @Id";

            BancoDeDados.Conexao.Query<UsuarioPerfil>(sql, new {
                Id = id
            });
            Console.WriteLine("");
        }
    }
}