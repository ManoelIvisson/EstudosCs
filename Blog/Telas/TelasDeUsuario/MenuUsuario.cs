namespace Blog.Telas.TelasDeUsuario {
    public static class MenuUsuario {

        public static void CarregarTela(){
            Console.Clear();
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Criar novo usuário");
            Console.WriteLine("2 - Atualizar usuário");
            Console.WriteLine("3 - Ler usuários");
            Console.WriteLine("4 - Deletar usuário");
            Console.WriteLine("0 - Voltar ao menu");
            var opcao = int.Parse(Console.ReadLine()!);

            switch (opcao) {
                case 1: 
                    TelaCadastroUsuario.CadastrarUsuario();
                break;
                case 2: 
                    TelaAtualizarUsuario.AtualizarUsuario();
                break;
                case 3: 
                    TelaListarUsuario.ListarUsuariosComPerfis();
                break;
                case 4: 
                    TelaDeletarUsuario.DeletarUsuario();
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
