namespace Blog.Telas.TelasDeCategoria {
    public static class MenuCategoria {

        public static void CarregarTela(){
            Console.Clear();
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Criar nova categoria");
            Console.WriteLine("2 - Atualizar categoria");
            Console.WriteLine("3 - Ler categorias");
            Console.WriteLine("4 - Ler postagem por categoria");
            Console.WriteLine("5 - Deletar categoria");
            Console.WriteLine("0 - Voltar ao menu");
            var opcao = short.Parse(Console.ReadLine()!);

            switch (opcao) {
                case 1: 
                    TelaCadastroCategoria.CadastrarCategoria();
                break;
                case 2: 
                    TelaAtualizarCategoria.AtualizarCategoria();
                break;
                case 3: 
                    TelaListarCategorias.ListarCategorias();
                break;
                case 4: 
                    TelaListarCategorias.ListarPostagensDeUmaCategoria();
                break;
                case 5: 
                    TelaDeletarCategoria.DeletarCategoria();
                break;
                case 0: 
                    Menu.Inicio();
                break;
                default: CarregarTela(); break;
            }
            CarregarTela();
        }
    }
}