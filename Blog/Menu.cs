using Blog.Telas.TelasDePerfil;
using Blog.Telas.TelasDeUsuario;

public static class Menu{
    public static void Inicio() {
        Console.Clear();
        Console.WriteLine("Bem vindo ao blog Console no Console");
        Console.WriteLine("Ir para: ");
        Console.WriteLine("1 - Aba de Usuários");
        Console.WriteLine("2 - Aba de Perfis");
        Console.WriteLine("3 - Aba de Categorias");
        Console.WriteLine("4 - Aba de Posts");
        Console.WriteLine("5 - Aba de Tags");
        Console.WriteLine("0 - Sair");
        var opcao = Console.ReadLine();

        switch (opcao) {
            case "1": MenuUsuario.CarregarTela(); break;
            case "2": MenuPerfil.CarregarTela(); break;
            case "0": System.Environment.Exit(0); break;
            default:
                Console.WriteLine("Opção Inválida, voltando ao menu... ");
                Inicio(); break;
        }
    }
}
