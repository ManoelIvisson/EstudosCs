using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;

namespace Blog.Telas.TelasDeUsuario {
    public static class TelaAtualizarUsuario {
        public static void AtualizarUsuario(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Atualização de Usuário =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Usuario>();
            var usuario = repositorio.Get(Verificacao.CarregarTelaUsuario());

            Console.WriteLine("Escolha o você deseja atualizar: ");
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - E-mail");
            Console.WriteLine("3 - Senha");
            Console.WriteLine("4 - Bio");
            var opcao = Console.ReadLine();
            var alteracao = "";

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
    }
}
