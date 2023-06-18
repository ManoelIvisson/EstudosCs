using System.Text.RegularExpressions;

namespace EditorHtml {
    public class Visualizador {
        public static void Mostrar(string texto) {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.WriteLine("-----------");
            Replace(texto);
            Console.WriteLine("-----------");
            Console.ReadKey();
            Menu.Mostrar();
        
        }

        public static void Replace(string texto) {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var palavras = texto.Split(' ');
            
            for (int i = 0; i < palavras.Length; i++) {
                if (strong.IsMatch(palavras[i])) {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(palavras[i].Substring(palavras[i].IndexOf('>') + 1, (palavras[i].LastIndexOf('<') - 1) - palavras[i].IndexOf('>')).ToUpper());
                    Console.Write(' ');
                } else {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(palavras[i]);
                    Console.Write(' ');
                }
            }
        }

        public static void BuscarArquivo() {
            Console.WriteLine("Onde está o arquivo que deseja abrir? ");
            var caminho = Console.ReadLine();
            var texto = "";

            using (var arquivo = new StreamReader(caminho!)) {
                texto = arquivo.ReadToEnd();
            }

            Mostrar(texto);
        }
    }
}