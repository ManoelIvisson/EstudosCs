using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Telas.TelasDeUsuario {
    public static class TelaDeletarUsuario {
        public static void DeletarUsuario(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Deletar Usuário =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Usuario>();

            Console.Write("Digite seu email: ");
            var email = Console.ReadLine();
            Console.Write("Digite sua senha: ");
            var senha = Console.ReadLine();
            int id = TelaAtualizarUsuario.VerficarUsuario(email, senha);

            repositorio.Deletar(id);
            DeletarPerfisVinculados(id);
            Console.WriteLine("Usuario Deletado com sucesso");
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