using System.Text;

namespace EditorHtml {
    public static class Editor {
        public static void Mostrar() {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-----------");
            Iniciar();

        }

        public static void Iniciar() {
            var arquivo = new StringBuilder();

            do {
                arquivo.Append(Console.ReadLine());
                arquivo.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("----------------");
            Console.WriteLine("Deseja salvar o arquivo? ");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            short opcao = short.Parse(Console.ReadLine()!);

            if (opcao == 1) {
                Salvar(arquivo.ToString());
            } else {
                Visualizador.Mostrar(arquivo.ToString());
            }

        }

        public static void Salvar(string texto) {
            Console.WriteLine("Digite o caminho para salvar o arquivo: ");
            var caminho = Console.ReadLine()!;

            using (var arquivo = new StreamWriter(caminho)) {
                arquivo.Write(texto);
            }

            Console.WriteLine("Salvo Com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Menu.Mostrar();
        }
    }
}
