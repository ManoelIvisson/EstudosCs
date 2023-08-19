using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;

namespace Blog.Telas.TelasDePostagem {
    public static class TelaAtualizarPostagem {
        public static void AtualizarPostagem(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Atualização de Postagem =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Postagem>();

            Console.WriteLine("Digite o id da postagem: ");
            var id = int.Parse(Console.ReadLine()!);
            var postagem = repositorio.Get(id);

            Console.WriteLine("Escolha o você deseja atualizar: ");
            Console.WriteLine("1 - Categoria");
            Console.WriteLine("2 - Autor");
            Console.WriteLine("3 - Título");
            Console.WriteLine("4 - Resumo");
            Console.WriteLine("5 - Conteúdo");
            Console.WriteLine("6 - Slug");
            var opcao = short.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1: 
                    Console.Write("Nova Categoria: ");
                    postagem.CategoriaId = Verificacao.CarregarTelaViaSlug("Categoria");
                    break;
                case 2: 
                    Console.Write("Novo Autor: ");
                    postagem.AutorId = Verificacao.CarregarTelaUsuario();
                    break;
                case 3: 
                    Console.Write("Novo Título: ");
                    postagem.Titulo = Console.ReadLine();
                    break;
                case 4: 
                    Console.Write("Novo Resumo: ");
                    postagem.Resumo = Console.ReadLine();
                    break;
                case 5: 
                    Console.Write("Novo Conteúdo: ");
                    postagem.Corpo = Console.ReadLine();
                    break;
                case 6: 
                    Console.Write("Novo Slug: ");
                    postagem.Slug = Console.ReadLine();
                    break;
                default: break;
            }

            repositorio.Atualizar(postagem);
            postagem.DataUltimaAtualizacao = DateTime.Now;
        }
    }
}
