using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelasDeUsuario;
using Dapper;

namespace Blog.Telas.TelasDevinculo {
   public static class VinculoUsuarioPerfil {
        public static void Menu() {
            Console.Clear();
            Console.WriteLine("Vincular: ");
            Console.WriteLine("1 - Perfil a usuário");
            Console.WriteLine("3 - postagem a tag");
            var opcao = Console.ReadLine();

            switch (opcao) {
                // case "1": MenuUsuario.CarregarTela(); break;
                // case "2": MenuPerfil.CarregarTela(); break;
                case "0": System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Opção Inválida, voltando ao menu... ");
                    Menu(); break;
            }
        }

        public static void VunculoUsuarioPerfil(int usuarioId, int perfilId) {
            if (usuarioId == 0) {
                Console.Write("Digite seu email: ");
                var email = Console.ReadLine();
                Console.Write("Digite sua senha: ");
                var senha = Console.ReadLine();
                usuarioId = TelaAtualizarUsuario.VerficarUsuario(email, senha);
            }

            var sql = "INSERT INTO [UsuarioPerfil] VALUES (@UsuarioId, @PerfilId)";
            var repositorio = new Repositorio<UsuarioPerfil>();
            
            var vinculo = BancoDeDados.Conexao.Query<UsuarioPerfil>(sql, new {
                UsuarioId = usuarioId,
                PerfilId = perfilId
            });

            foreach (var item in vinculo) {
                repositorio.Criar(item);
            }
        }
        
   }
}