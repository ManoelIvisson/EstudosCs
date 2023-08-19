using Blog.Models;
using Blog.Repositories;

namespace Blog.Telas.TelasDeTag {
    public static class TelaCadastroTag {
        public static void CadastrarTag(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Cadastro de Tag =-=-=-=-=-=-=-=");
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            var tag = new Tag() {
                Nome = nome,
                Slug = slug
            };

            var repositorio = new Repositorio<Tag>();

            try {
                repositorio.Criar(tag);
                Console.WriteLine("Tag criada com sucesso!");
            } catch (Exception ex) {
                Console.WriteLine("Ocorreu um erro, talvez o Slug já exista");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                CadastrarTag();
            }

            // Console.WriteLine("Deseja vincular esse perfil a um usuário? S/N");
            // var opcao = Convert.ToChar(Console.ReadLine()!);
            // switch (opcao){
            //     case 'S': 
            //         VinculoUsuarioPerfil.VuncularUsuarioPerfil(0, perfil.Id);
            //     break;
            //     default: 
            //         MenuPerfil.CarregarTela();
            //     break;
            // }
            Console.ReadKey();
        }
    }
}