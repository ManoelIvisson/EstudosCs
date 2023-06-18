using System.Text;

class Program {
    static void Main(string[] args) {
        string bom = "Deus é Bom";
        string tempoTodo = "tempo todo";
        string adicao = "";
        adicao = adicao.Insert(0, "Ohh Glória!!");
        Console.WriteLine(string.Format("{0} o {1} e o {1} {0} {2}".ToUpper(), bom.ToUpper(), tempoTodo.ToUpper(), adicao));

        // Método Contains
        // Console.WriteLine(bom.Contains("DeUs", StringComparison.OrdinalIgnoreCase));

        // Método CompareTo
        // Console.WriteLine(tempoTodo.CompareTo("tempo tod"));

        // Métodos StartsWith e EndsWith
        // Console.WriteLine(bom.StartsWith("DeuS", StringComparison.OrdinalIgnoreCase));
        // Console.WriteLine(tempoTodo.EndsWith("todo"));

        // Método Equals
        // Console.WriteLine(bom.Equals("Deus é bom"));
        // Console.WriteLine(bom.Equals("Deus é bom", StringComparison.OrdinalIgnoreCase));

        // Métodos IndexOf e LastIndexOF
        // Console.WriteLine(bom.IndexOf("é"));
        // Console.WriteLine(tempoTodo.LastIndexOf('o'));

        // Métodos Legais hehe: ToLower, ToUpper, Insert e Remove
        // bom = bom.Insert(6, " MUITO ");
        // Console.WriteLine(bom);
        // Console.WriteLine(bom.Remove(12, 1));

        // Mais métodos de manipulção de string: Replace, Split, Substring e Trim
        // Console.WriteLine(bom.Replace("Bom", "BOM DEMAIS!"));
        // Console.WriteLine(tempoTodo.Split(" ")[1]);
        // Console.WriteLine(bom.Substring(0, bom.IndexOf(' ')));
        // Console.WriteLine(tempoTodo.Trim()); // O Trim() remove os espaços em branco no início e no final 

        // Uma forma de acrescentar strings a outra string sem prejudicar tanto a memória
        // var texto = new StringBuilder();
        // texto.Append("Eu sou um texto");
        // texto.Append(", um texto muito lindo por sinal... ");
        // texto.Append("Num é verdade?");

        // Console.WriteLine(texto);

        // GUID - Global Unique Indentifcantion
        var id = Guid.NewGuid();
        string ids = id.ToString();

        Console.WriteLine(ids);
    }
}
