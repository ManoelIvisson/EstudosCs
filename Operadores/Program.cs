class Program {
    static void Main(string[] args) {
        double x = 0;
        x += 5; // resultado = 5, mesma coisa que x = x + 5
        x -= 3; // resultado = 2, mesma coisa que x = x - 5
        x *= 2; // resultado = 4, mesma coisa que x = x * 5
        x /= 4; // resultado = 1, mesma coisa que x = x / 5
        x++;

        Console.WriteLine(x);
        Console.WriteLine(x + 100 <= 100);
        x++;
        Console.WriteLine(x);
    }
}

