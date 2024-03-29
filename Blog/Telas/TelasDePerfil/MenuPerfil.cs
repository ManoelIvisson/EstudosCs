namespace Blog.Telas.TelasDePerfil {
    public static class MenuPerfil {

        public static void CarregarTela(){
            Console.Clear();
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Criar novo perfil");
            Console.WriteLine("2 - Atualizar perfil");
            Console.WriteLine("3 - Ler perfis");
            Console.WriteLine("4 - Deletar perfil");
            Console.WriteLine("0 - Voltar ao menu");
            var opcao = short.Parse(Console.ReadLine()!);

            switch (opcao) {
                case 1: 
                    TelaCadastroPerfil.CadastrarPerfil();
                break;
                case 2: 
                    TelaAtualizarPerfil.AtualizarPerfil();
                break;
                case 3: 
                    TelaListarperfis.ListarPerfis();
                break;
                case 4: 
                    TelaDeletarPerfil.DeletarPerfil();
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