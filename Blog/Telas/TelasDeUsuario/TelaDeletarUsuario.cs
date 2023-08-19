using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;
using Dapper;

namespace Blog.Telas.TelasDeUsuario {
    public static class TelaDeletarUsuario {
        public static void DeletarUsuario(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Deletar Usuário =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Usuario>();

            int id = Verificacao.CarregarTelaUsuario();

            try {
                repositorio.Deletar(id);
                DeletarPerfisVinculados(id);
                Console.WriteLine("Usuario Deletado com sucesso");
            } catch (Exception ex) {
                Console.WriteLine("Não foi possível deletar o usuário");
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        public static void DeletarPerfisVinculados(int id){
            var sql = @"SELECT * FROM [UsuarioPerfil] WHERE [UsuarioId] = @Id";
            var repositorio = new Repositorio<UsuarioPerfil>();

            var perfisVinculados = BancoDeDados.Conexao.Query<UsuarioPerfil>(sql, new {
                Id = id
            });

            foreach (var vinculo in perfisVinculados) {
                repositorio.Deletar(vinculo);
            }
            Console.ReadKey();
        }
    }
}