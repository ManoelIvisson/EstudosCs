using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;

namespace Blog.Telas.TelasDeTag {
    public static class TelaAtualizarTag {
        public static void AtualizarTag(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Atualização de Tag =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Tag>();
            var tag = repositorio.Get(Verificacao.CarregarTelaViaSlug("Tag"));
            
            if (tag == null) {
                Console.WriteLine("O slug não foi encontrado, por favor tente novamente");
                Console.ReadKey();
                AtualizarTag();
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
                        tag.Nome = alteracao;
                        break;
                    case "2": 
                        Console.Write("Novo Slug: ");
                        alteracao = Console.ReadLine();
                        tag.Slug = alteracao;
                        break;
                    default: 
                        Console.WriteLine("Por favor escolha uma opção válida");
                        Console.ReadKey();
                        AtualizarTag();
                    break;
                }

                try {
                    repositorio.Atualizar(tag);
                } catch (Exception ex) {
                    Console.WriteLine("Não foi possível atualizar a tag");
                    Console.WriteLine(ex);
                }
            }
        }
    }
}