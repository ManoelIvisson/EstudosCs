using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;

namespace Blog.Telas.TelasDeCategoria {
    public static class TelaAtualizarCategoria {
        public static void AtualizarCategoria(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Atualização de Categoria =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Categoria>();
            var categoria = repositorio.Get(Verificacao.CarregarTelaViaSlug("Categoria"));
            
            if (categoria == null) {
                Console.WriteLine("O slug não foi encontrado, por favor tente novamente");
                Console.ReadKey();
                AtualizarCategoria();
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
                        categoria.Nome = alteracao;
                        break;
                    case "2": 
                        Console.Write("Novo Slug: ");
                        alteracao = Console.ReadLine();
                        categoria.Slug = alteracao;
                        break;
                    default: 
                        Console.WriteLine("Por favor escolha uma opção válida");
                        Console.ReadKey();
                        AtualizarCategoria();
                    break;
                }

                try {
                    repositorio.Atualizar(categoria);
                } catch (Exception ex) {
                    Console.WriteLine("Não foi possível atualizar a categoria");
                    Console.WriteLine(ex);
                }
            }
        }
    }
}