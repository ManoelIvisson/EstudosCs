using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;

namespace Blog.Telas.TelasDeCategoria {
    public static class TelaDeletarCategoria {
        public static void DeletarCategoria(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Deletar Categoria =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Categoria>();

            int id = Verificacao.CarregarTelaViaSlug("Categoria");
            if (id == 0) {
                Console.WriteLine("a categoria não foi encontrada, por favor tente novamente");
                Console.ReadKey();
                DeletarCategoria();
            }

            try {
                repositorio.Deletar(id);
                Console.WriteLine("Categoria Deletada com sucesso");
            } catch (Exception ex) {
                Console.WriteLine("Não foi possível deletar a Categoria");
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}