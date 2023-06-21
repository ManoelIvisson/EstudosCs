class Program {
    static void Main(string[] args) {
        Console.Clear();

        // var meuArray = new int[5] {80, 32, 3, 4, 2};
        // meuArray[4] += 3; 

        // for (var indice = 0; indice < meuArray.Length; indice++) {
        //     Console.WriteLine(meuArray[indice]);
        // }

        // foreach (var item in meuArray) {
        //     Console.WriteLine(item);
        // }

        // var funcionarios = new funcionario[5];
        // for (var item = 0; item < funcionarios.Length; item++) {
        //     funcionarios[item] = new funcionario() { Id = Guid.NewGuid()};
        // }

        // foreach (var funcionario in funcionarios) {
        //     Console.WriteLine(funcionario.Id);
        // }

        var primeiro = new string[2] {"Anthony", "Ronaldinho"};
        // var segundo = new string[2] {"Anderson", "Roberto"};
        var segundo = primeiro;

        // primeiro.CopyTo(segundo, 1);
        primeiro[0] = "Steve";

        Console.WriteLine(segundo[0]);
    }

    struct funcionario {
        public Guid Id;
    }
}