using Blog.Telas.TelasDeCategoria;
using Blog.Telas.TelasDePerfil;
using Blog.Telas.TelasDePostagem;
using Blog.Telas.TelasDeTag;
using Blog.Telas.TelasDeUsuario;
using Blog.Telas.TelasDevinculo;

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
        Console.WriteLine("6 - Aba de Vinculção entre Usuário e Perfil");
        Console.WriteLine("7 - Aba de Vinculção entre Postgem e Tag");
        Console.WriteLine("0 - Sair");
        var opcao = int.Parse(Console.ReadLine()!);

        switch (opcao) {
            case 1: 
                MenuUsuario.CarregarTela(); 
            break;
            case 2: 
                MenuPerfil.CarregarTela(); 
            break;
            case 3: 
                MenuCategoria.CarregarTela(); 
            break;
            case 4:
                MenuPostagem.CarregarTela();
            break;
            case 5: 
                MenuTag.CarregarTela(); 
            break;
            case 6: 
                VinculoUsuarioPerfil.VuncularUsuarioPerfil();
            break;
            case 7: 
                VinculoPostagemTag.VuncularPostagemTag();
            break;
            case 0: 
                System.Environment.Exit(0); 
            break;
            default:
                Console.WriteLine("Opção Inválida, voltando ao menu... ");
                Console.ReadKey();
                Inicio(); break;
        }
    }
}
