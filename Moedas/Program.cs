using System.Globalization;

class Program {
    static void Main(string[] args){
        Console.Clear();

        // var cultura = new CultureInfo("pt-BR");
        // Console.WriteLine(cultura);

        decimal dinheiro = 49.80m;

        Console.WriteLine(Math.Round(dinheiro));
        Console.WriteLine(Math.Ceiling(dinheiro));
        Console.WriteLine(Math.Floor(dinheiro));
    }
}
