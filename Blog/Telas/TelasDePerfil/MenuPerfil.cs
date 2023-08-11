namespace Blog.Telas.TelasDePerfil {
    public static class MenuPerfil {

        public static void CarregarTela(){
            Console.Clear();
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Criar novo perfil");
            Console.WriteLine("2 - Atualizar perfil");
            Console.WriteLine("3 - Ler perfis");
            Console.WriteLine("4 - Deletar perfil");
            var opcao = Console.ReadLine();

            switch (opcao) {
                case "1": 
                    TelaCadastroPerfil.CadastrarPerfil();
                break;
                default: CarregarTela(); break;
            }
            CarregarTela();
        }
    }
}