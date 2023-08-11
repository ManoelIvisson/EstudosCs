using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelasDevinculo;

namespace Blog.Telas.TelasDePerfil {
    public static class TelaCadastroPerfil {
        public static void CadastrarPerfil(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Cadastro de Perfil =-=-=-=-=-=-=-=");
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            var perfil = new Perfil() {
                Nome = nome,
                Slug = slug
            };

            var repositorio = new Repositorio<Perfil>();

            try {
                repositorio.Criar(perfil);
                Console.WriteLine("Perfil criado com sucesso");
            } catch (Exception ex) {
                Console.WriteLine("Ocorreu um erro, talvez o Slug já exista");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                CadastrarPerfil();
            }

            Console.WriteLine("Deseja vincular esse perfil a um usuário? S/N");
            var opcao = Convert.ToChar(Console.ReadLine()!);
            switch (opcao){
                case 'S': 
                    VinculoUsuarioPerfil.VunculoUsuarioPerfil(0, perfil.Id);
                break;
                default: 
                    MenuPerfil.CarregarTela();
                break;
            }
            Console.ReadKey();
        }
    }
}