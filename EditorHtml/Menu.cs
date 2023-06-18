namespace EditorHtml{
    public static class Menu {
        public static void Mostrar() {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();

            DesenharTela(30, 10);
            EscreverOpcoes();

            short opcao = short.Parse(Console.ReadLine()!);
            ManipuladorDasOpcoes(opcao);
        } 

        public static void DesenharTela(int numeroColunas, int numeroLinhas) {
            CriarBordas(numeroColunas, "+", "-");

            for (int lines = 0; lines <= numeroLinhas; lines++) {
                CriarBordas(numeroColunas, "|", " ");
            }

            CriarBordas(numeroColunas, "+", "-");
        }

        static void CriarBordas(int numeroColunas, string pontasDaBorda, string caractererDaBorda) {
            Console.Write(pontasDaBorda);
            for (int i = 0; i<= numeroColunas; i++) {
                Console.Write(caractererDaBorda);
            }
            Console.Write(pontasDaBorda);
            Console.Write("\n");
        }

        public static void EscreverOpcoes() {
            Console.SetCursorPosition(3, 0);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("============");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("2 - Abrir arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 8);
            Console.Write("Opção: ");
        }
    
        public static void ManipuladorDasOpcoes(short opcao) {
            switch (opcao) {
                case 1: Editor.Mostrar(); break;
                case 2: Visualizador.BuscarArquivo(); break;
                case 0: {
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                }
                default: Mostrar(); break;
            }
        }
    }
}
