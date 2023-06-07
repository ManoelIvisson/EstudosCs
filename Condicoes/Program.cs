class Program {
    static void Main(string[] args) {
        int idade = 18;
        int maioridade = 21;
        int idadeMaxima = 65;

        if (idade >= maioridade && idade < idadeMaxima) {
            Console.WriteLine("É um adulto com idade abaixo de 65 anos");
        } else {
            Console.WriteLine("É um jovem com idade menor que 18 anos ou um idoso acima de 65");
        }
    }
}

