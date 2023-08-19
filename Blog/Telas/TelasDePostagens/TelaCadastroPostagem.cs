using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;
using Blog.Telas.TelasDevinculo;

namespace Blog.Telas.TelasDePostagem {
    public static class TelaCadastroPostagem {
        public static void CadastrarPostagem(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Cadastro de Postagem =-=-=-=-=-=-=-=");
            Console.Write("Categoria da postagem: ");
            var categoria = Verificacao.CarregarTelaViaSlug("Categoria");
            Console.Write("Autor: ");
            var autor = Verificacao.CarregarTelaUsuario();
            Console.Write("Título: ");
            var titulo = Console.ReadLine();
            Console.Write("Resumo: ");
            var resumo = Console.ReadLine();
            Console.Write("Corpo: ");
            var corpo = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            var postagem = new Postagem() {
                CategoriaId = categoria,
                AutorId = autor,
                Titulo = titulo,
                Resumo = resumo,
                Corpo = corpo,
                Slug = slug,
                DataCriacao = DateTime.Now,
                DataUltimaAtualizacao = DateTime.Now,
            };


            var repositorio = new Repositorio<Postagem>();

            repositorio.Criar(postagem);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cadastro da postagem concluído com sucesso");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            
            // Console.WriteLine("Deseja vincular esse usuário a uma tag já existente? S/N");
            // var opcao = Convert.ToChar(Console.ReadLine()!);
            // switch (opcao){
            //     case 'S': 
            //         VinculoUsuarioPerfil.VuncularUsuarioPerfil(usuario.Id, 0);
            //     break;
            //     default: 
            //         MenuUsuario.CarregarTela();
            //     break;
            // }
            Console.ReadKey();
        }
    }
}
