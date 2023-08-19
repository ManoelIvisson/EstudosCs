using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;

namespace Blog.Telas.TelasDePerfil {
    public static class TelaAtualizarPerfil {
        public static void AtualizarPerfil(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Atualização de Perfil =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Perfil>();
            var perfil = repositorio.Get(Verificacao.CarregarTelaViaSlug("Perfil"));
            
            if (perfil == null) {
                Console.WriteLine("O slug não foi encontrado, por favor tente novamente");
                Console.ReadKey();
                AtualizarPerfil();
            } else {
                Console.WriteLine("Escolha o que você deseja atualizar: ");
                Console.WriteLine("1 - Nome");
                Console.WriteLine("2 - Slug");
                var opcao = Console.ReadLine();
                var alteracao = "";

                switch (opcao)
                {
                    case "1": 
                        Console.Write("Novo Nome: ");
                        alteracao = Console.ReadLine();
                        perfil.Nome = alteracao;
                        break;
                    case "2": 
                        Console.Write("Novo Slug: ");
                        alteracao = Console.ReadLine();
                        perfil.Slug = alteracao;
                        break;
                    default: 
                        Console.WriteLine("Por favor escolha uma opção válida");
                        Thread.Sleep(1500);
                    break;
                }

                try {
                    repositorio.Atualizar(perfil);
                } catch (Exception ex) {
                    Console.WriteLine("Não foi possível atualizar o perfil");
                    Console.WriteLine(ex);
                }
            }
        }
    }
}