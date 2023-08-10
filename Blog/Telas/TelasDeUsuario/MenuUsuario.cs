namespace Blog.Telas.TelasDeUsuario {
    public static class MenuUsuario {

        public static void CarregarTela(){
            Console.Clear();
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Criar novo usuário");
            Console.WriteLine("2 - Atualizar usuário");
            Console.WriteLine("3 - Ler usuários");
            Console.WriteLine("4 - Deletar usuário");
            var opcao = Console.ReadLine();

            switch (opcao) {
                case "1": 
                    TelaCadastroUsuario.CadastrarUsuario();
                break;
                case "2": 
                    TelaAtualizarUsuario.AtualizarUsuario();
                break;
                case "3": 
                    TelaListarUsuario.ListarUsuariosComPerfis();
                break;
                default: CarregarTela(); break;
            }
        }
    }
}
