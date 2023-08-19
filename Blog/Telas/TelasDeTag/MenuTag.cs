namespace Blog.Telas.TelasDeTag {
    public static class MenuTag {

        public static void CarregarTela(){
            Console.Clear();
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Criar nova tag");
            Console.WriteLine("2 - Atualizar tag");
            Console.WriteLine("3 - Ler tags");
            Console.WriteLine("4 - Deletar tag");
            Console.WriteLine("0 - Voltar ao menu");
            var opcao = short.Parse(Console.ReadLine()!);

            switch (opcao) {
                case 1: 
                    TelaCadastroTag.CadastrarTag();
                break;
                case 2: 
                    TelaAtualizarTag.AtualizarTag();
                break;
                case 3: 
                    TelaListarTags.ListarTags();
                break;
                case 4: 
                    TelaDeletarTag.DeletarTag();
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