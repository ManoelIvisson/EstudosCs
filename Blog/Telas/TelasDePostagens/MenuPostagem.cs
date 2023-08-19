namespace Blog.Telas.TelasDePostagem {
    public static class MenuPostagem {

        public static void CarregarTela(){
            Console.Clear();
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Criar nova postagem");
            Console.WriteLine("2 - Atualizar postagem");
            Console.WriteLine("3 - Ler todas as postagens");
            Console.WriteLine("4 - Deletar postagem");
            Console.WriteLine("0 - Voltar ao menu");
            var opcao = int.Parse(Console.ReadLine()!);

            switch (opcao) {
                case 1: 
                    TelaCadastroPostagem.CadastrarPostagem();
                break;
                case 2: 
                    TelaAtualizarPostagem.AtualizarPostagem();
                break;
                case 3: 
                    TelaListarPostagem.ListarPostagens();
                break;
                case 4: 
                    TelaDeletarPostagem.DeletarPostagem();
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
