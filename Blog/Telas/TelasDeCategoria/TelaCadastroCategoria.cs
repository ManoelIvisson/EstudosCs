using Blog.Models;
using Blog.Repositories;

namespace Blog.Telas.TelasDeCategoria {
    public static class TelaCadastroCategoria {
        public static void CadastrarCategoria(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Cadastro de Categoria =-=-=-=-=-=-=-=");
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            var categoria = new Categoria() {
                Nome = nome,
                Slug = slug
            };

            var repositorio = new Repositorio<Categoria>();

            try {
                repositorio.Criar(categoria);
                Console.WriteLine("Categoria criada com sucesso!");
            } catch (Exception ex) {
                Console.WriteLine("Ocorreu um erro, talvez o Slug já exista");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                CadastrarCategoria();
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