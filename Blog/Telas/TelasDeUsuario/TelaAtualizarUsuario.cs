using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Telas.TelasDeUsuario {
    public static class TelaAtualizarUsuario {
        public static void AtualizarUsuario(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Atualização de Usuário =-=-=-=-=-=-=-=");
            Console.Write("Digite seu email: ");
            var email = Console.ReadLine();
            Console.Write("Digite sua senha: ");
            var senha = Console.ReadLine();
            Console.WriteLine("Escolha o você deseja atualizar: ");
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - E-mail");
            Console.WriteLine("3 - Senha");
            Console.WriteLine("4 - Bio");
            var opcao = Console.ReadLine();
            var alteracao = "";

            var repositorio = new Repositorio<Usuario>();
            var usuario = repositorio.Get(VerficarUsuario(email, senha));

            switch (opcao)
            {
                case "1": 
                    Console.Write("Novo Nome: ");
                    alteracao = Console.ReadLine();
                    usuario.Nome = alteracao;
                    break;
                case "2": 
                    Console.Write("Novo E-mail: ");
                    alteracao = Console.ReadLine();
                    usuario.Email = alteracao;
                    break;
                case "3": 
                    Console.Write("Nova Senha: ");
                    alteracao = Console.ReadLine();
                    usuario.SenhaHash = alteracao;
                    break;
                case "4": 
                    Console.Write("Nova Bio: ");
                    alteracao = Console.ReadLine();
                    usuario.Bio = alteracao;
                    break;
                default: break;
            }

            repositorio.Atualizar(usuario);
        }

        public static int VerficarUsuario(string? email, string? senha){
            var sql = "SELECT [ID] FROM [Usuario] WHERE [Email] = @Email AND [SenhaHash] = @Senha";

            var id = BancoDeDados.Conexao.Query<Usuario>(sql, new {
                Email = email,
                Senha = senha
            });

            foreach (var item in id){
                return item.Id;
            }

            return 0;
        }
    }
}
