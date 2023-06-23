class Program {
    static void Main(string[] args) {
        Console.Clear();

        var mercado = new string[2] {"Salsicha", "Tomate"};

        try {
            // for (var item = 0; item < 3; item++) {
            //     Console.WriteLine(mercado[item]);
            // }

            Cadastrar("");
        } catch (IndexOutOfRangeException ex) {
            Console.WriteLine($"Erro: {ex}");
            Console.WriteLine("O índice informado ultrapassou o limite");

        } catch (ArgumentNullException ex) {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine("Falha ao cadastrar texto nulo ou vazio");
        } catch (MinhaExcecao ex) {
            Console.WriteLine($"O erro ocorreu em {ex.DataErro.ToString("r")}");
            Console.WriteLine(ex.Message);
        } catch (Exception ex){
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine("Vixi, deu errado");
        } finally {
            Console.WriteLine("Não sei se deu certo ou errado, mas estou aqui hehehe");
        }

        // Console.WriteLine("Dá proxima vez dá certo");
    }

    public static void Cadastrar(string texto) {
        if (string.IsNullOrEmpty(texto)) {
            throw new MinhaExcecao(DateTime.Now);
        }
    }

    public class MinhaExcecao: Exception {

        public MinhaExcecao(DateTime data) {
            DataErro = data;
        }

        public DateTime DataErro;
    }
}
