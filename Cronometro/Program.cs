class Program {
    static void Main(string[] args) {
        Menu();
    } 

    static void Menu() {
        Console.Clear();
        Console.WriteLine("Bem vindo ao Cronômetro 100% atualizado - Escolha a opção de tempo em que desejas cronometrar");
        Console.WriteLine("S - Segundo => 10s - 10 segundos");
        Console.WriteLine("M - Minuto => 1m - 1 minuto");
        Console.WriteLine("0 - Sair");
        Console.WriteLine("Quanto tempo deseja cronometrar? ");

        string data = Console.ReadLine()!.ToLower();
        char tipo = data.Last();
        int tempo = int.Parse(data.Substring(0, data.Length - 1));
        // char tipo = char.Parse(data.Substring(data.Length - 1, 1));
        int multiplicador = 1;

        if (tipo == 'm') 
            multiplicador = 60;
        
        if (tempo == 0)
            System.Environment.Exit(0);
        
        char tipoContagem = TipoContagem();

        PreIniciar(tempo * multiplicador, tipoContagem);
    }

    static char TipoContagem() {
        Console.WriteLine("Você quer cronometrar de forma progressiva(ex.: de 0 a 10) ou de forma regressiva(ex.: de 10 a 0)?");
        Console.WriteLine("P - Progressiva");
        Console.WriteLine("R - Regressiva");

        char tipoContagem = char.Parse(Console.ReadLine()!.ToLower());
        return tipoContagem;
    }

    static void PreIniciar(int tempo, char tipoContagem) {
        Console.Clear();
        Console.WriteLine("Prepare-se... ");
        Thread.Sleep(1000);
        Console.WriteLine("Atenção... ");
        Thread.Sleep(1000);
        Console.WriteLine("Vaiii... ");
        Thread.Sleep(500);

        if (tipoContagem == 'p') {
            IniciarContProgressiva(tempo);
        } else {
            IniciarContRegressiva(tempo);
        }
    }

    static void IniciarContProgressiva(int tempo){
        int tempoAtual = 0;

        while (tempoAtual != tempo) {
            Console.Clear();
            tempoAtual++;
            Console.WriteLine(tempoAtual);
            Thread.Sleep(1000);
        }

        Console.Clear();
        Console.WriteLine("Cronometro finalizado");
        Thread.Sleep(2500);
        Menu();
    }

    static void IniciarContRegressiva(int tempo) {
        for (int i = tempo; i != 0; i--) {
            Console.Clear();
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }

        Console.Clear();
        Console.WriteLine("Cronômetro finalizado");
        Thread.Sleep(2500);
        Menu();
    }
}
