
class Program {
    static void Main(string[] args) {
        Menu();
    }

    static void Menu(){
        Console.Clear();
        Console.WriteLine("Escolha o que desejas fazer: ");
        Console.WriteLine("1 - Abrir arquivo");
        Console.WriteLine("2 - Criar novo arquivo");
        Console.WriteLine("0 - Sair");

        short opcao = short.Parse(Console.ReadLine()!);

        switch (opcao) {
            case 0: System.Environment.Exit(0); break;
            case 1: Abrir(); break;
            case 2: Editar(); break;
            default: Menu(); break;
        }
    }

    static void Abrir() {
        Console.Clear();
        Console.WriteLine("Qual o caminho do arquivo?");
        string caminho = Console.ReadLine()!;
        string texto = "";
        short opcao = 0;

        using(var arquivo = new StreamReader(caminho)) {
            texto = arquivo.ReadToEnd();
            Console.WriteLine(texto);

            Console.WriteLine("Deseja editar esse arquivo?");
            Console.WriteLine("1 - Editar");
            Console.WriteLine("2 - Voltar ao menu");
            opcao = short.Parse(Console.ReadLine()!);
            
        }
        switch (opcao) {
                case 1: Editar(texto, caminho); break;
                case 2: Menu(); break;
                default: Menu(); break;
            }
    }

    static void Editar(string editarTexto = "", string caminhoOriginal = "") {
        Console.Clear();
        Console.WriteLine("Digite seu texto abaixo (ESC para sair): ");
        Console.WriteLine("--------------------------");
        string texto = "";

        //A variável editarTexto só não será vazia quando o usuário tiver escolhido a opção de editar dentro da função abrir
        if (editarTexto != "") {
            texto = editarTexto;
        }

        do {
            texto += Console.ReadLine()!;
            texto += Environment.NewLine;
        } while (Console.ReadKey().Key != ConsoleKey.Escape);

        if (editarTexto != "") {
            Console.WriteLine("Formas de Salvar: ");
            Console.WriteLine("1 - Salvar as alterações no arquivo original");
            Console.WriteLine("2 - Salvar em um novo arquivo");
            Console.WriteLine("3 - Descartar alterações");
            Console.WriteLine(caminhoOriginal);
            short modoSalvar = short.Parse(Console.ReadLine()!);

            switch (modoSalvar) {
                case 1: Salvar(texto, caminhoOriginal); break;
                case 2: Salvar(texto); break;
                case 3: Menu(); break;
                default: Menu(); break;
            }
        } else {
            Salvar(texto);
        }
    }

    static void Salvar(string texto, string caminhoOriginal = "") {
        Console.Clear();
        var caminho = "";

        if (caminhoOriginal == ""){
            Console.WriteLine("Qual o caminho para salvar o arquivo? ");
            caminho = Console.ReadLine();
        } else {
            caminho = caminhoOriginal;
        }

        using(var arquivo = new StreamWriter(caminho!)) {
            arquivo.Write(texto);
        }

        Console.WriteLine($"Arquivo {caminho} salvo com sucesso!");
        Console.ReadLine();
        Menu();
    }
}
