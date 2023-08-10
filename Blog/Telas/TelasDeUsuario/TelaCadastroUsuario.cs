using Blog.Models;
using Blog.Repositories;

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
            
        }
    }
}


