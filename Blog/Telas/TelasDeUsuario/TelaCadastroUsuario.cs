using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelasDevinculo;

namespace Blog.Telas.TelasDeUsuario {
    public static class TelaCadastroUsuario {
        public static void CadastrarUsuario(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Cadastro de Usuário =-=-=-=-=-=-=-=");
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("E-mail: ");
            var email = Console.ReadLine();
            Console.Write("Senha: ");
            var senha = Console.ReadLine();
            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            var usuario = new Usuario() {
                Nome = nome,
                Email = email,
                SenhaHash = senha,
                Bio = bio,
                Imagem = "https://...",
                Slug = $"{nome}usr"
            };


            var repositorio = new Repositorio<Usuario>();

            repositorio.Criar(usuario);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Cadastro de usuário concluído com sucesso");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine("Deseja vincular esse usuário a um perfil já existente? S/N");
            var opcao = Convert.ToChar(Console.ReadLine()!);
            switch (opcao){
                case 'S': 
                    VinculoUsuarioPerfil.VuncularUsuarioPerfil(usuario.Id, 0);
                break;
                default: 
                    MenuUsuario.CarregarTela();
                break;
            }
            Console.ReadKey();
        }
    }
}
