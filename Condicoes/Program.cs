class Program {
    static void Main(string[] args) {
        // int idade = 18;
        // int maioridade = 21;
        // int idadeMaxima = 65;

        // Operador IF
        // if (idade >= maioridade && idade < idadeMaxima) {
        //     Console.WriteLine("É um adulto com idade abaixo de 65 anos");
        // } else {
        //     Console.WriteLine("É um jovem com idade menor que 18 anos ou um idoso acima de 65");
        // }

        // Operador Switch
        // string valor = "Manoel";

        // switch(valor) {
        //     case "André":
        //         Console.WriteLine("É André");
        //         break;
        //     case "Manoel":
        //         Console.WriteLine("Sou eu HEHE");
        //         break;
        //     default:
        //         Console.WriteLine("É Tiriricaaaa");
        //         break;
        // }


        // Laço de repetição: For
        // Console.Write("Digite um número: ");
        // int numero = Convert.ToInt32(Console.ReadLine());
        // double soma = 0;

        // for (double i = 1; i <= numero; i++) {
        //     soma += 1/i;
        //     Console.WriteLine(soma);
        // }
        // Console.ReadKey();

        // Laço de repetição: While
        // int valor = 0;

        // while (valor <= 5) {
        //     valor++;
        //     Console.WriteLine(valor);
        //     // valor++;
        // }

        // Laço de repetição: Do/While
        // int valor = 0;

        // do {
        //     Console.WriteLine(valor);
        //     valor++;
        // } while (valor < 5);

        //Structs e Enumeradores
        var produto =  new Produto(0, "Manoel", 20.0, ETipoProduto.Produto);

        Console.WriteLine(produto.Id);
        Console.WriteLine(produto.Nome);
        Console.WriteLine(produto.Preco);
        Console.WriteLine(produto.TipoProduto);
        Console.WriteLine((int)produto.TipoProduto);

    }
struct Produto {
        public Produto(int id, string nome, double preco, ETipoProduto tipo) {
            Id = id;
            Nome = nome;
            Preco = preco;
            TipoProduto = tipo;
        }

        public int Id;
        public string Nome;
        public double Preco;
        public ETipoProduto TipoProduto;

        public double PrecoEmDolar(double dolar) {
            return Preco * dolar;
        }
}
enum ETipoProduto {
    Servico = 1,
    Produto = 2,
}
}

