class Program {
    static void Main(string[] args) {
        Menu();
    }

    static void Menu() {
        Console.Clear();

        Console.WriteLine("Bem-vindo a Calculadora 100% atualizada - Qual operação desejas fazer? ");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Divisão");
        Console.WriteLine("4 - Multiplicação");
        Console.WriteLine("5 - Potenciação");
        Console.WriteLine("6 - Sair");

        Console.WriteLine("------------------");
        Console.Write("Selecione uma operação: ");
        short operacao = Convert.ToInt16(Console.ReadLine());

        switch (operacao) {
            case 1: Soma(); break;
            case 2: Subtracao(); break;
            case 3: Divisao(); break;
            case 4: Multiplicacao(); break;
            case 5: Potenciacao(); break;
            case 6: FinalizarPrograma(); break;
            default: Menu(); break;
        }
    }

    static void Soma() {
        Console.Clear(); //Limpa a tela do terminal 

        Console.Write("Digite um número: ");
        double numero1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite outro número: ");
        double numero2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("");

        double resultado = numero1 + numero2;
        Console.WriteLine($"O resultado da soma é {resultado}");

        Console.WriteLine("");

        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Menu();
    }

    static void Subtracao() {
        Console.Clear(); //Limpa a tela do terminal 

        Console.Write("Digite um número: ");
        double numero1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite outro número: ");
        double numero2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("");

        double resultado = numero1 - numero2;
        Console.WriteLine($"Primeiro valor {numero1} e Segundo valor {numero2}");
        Console.WriteLine($"O resultado da subtração é {resultado}");

        Console.WriteLine("");

        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Menu();
    }

    static void Divisao() {
        Console.Clear();

        Console.Write("Digite um número: ");
        double numero1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite outro número: ");
        double numero2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("");

        double resultado = numero1 / numero2;
        Console.WriteLine($"O resultado da divisão é {resultado}");

        Console.WriteLine("");

        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Menu();
    }

    static void Multiplicacao() {
        Console.Clear();

        Console.Write("Digite um número: ");
        double numero1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite outro número: ");
        double numero2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("");

        double resultado = numero1 * numero2;
        Console.WriteLine($"O resultado da multiplicação é {resultado}");
        
        Console.WriteLine("");

        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Menu();
    }

    static void Potenciacao() {
        Console.Clear();

        Console.Write("Digite um número(Base): ");
        double numero1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite outro número(Expoente): ");
        double numero2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("");

        double resultado = Math.Pow(numero1, numero2);
        // for (double i = 1; i <= numero2; i++) {
        //     resultado *= numero1;
        // }

        Console.WriteLine($"O resultado da potenciação é {resultado}");
        
        Console.WriteLine("");
        
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Menu();
    }
    
    static void FinalizarPrograma() {
        Console.WriteLine("Obrigado por usar a nossa calculadora! Volte sempre e traga mais um!");
        System.Environment.Exit(0);
    }
}
