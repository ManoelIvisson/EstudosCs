using Microsoft.Data.SqlClient;
class Program {
    static void Main(string[] args){
        const string coneccaoString = @"Server=.\SQLEXPRESS;Database=Balta;Integrated Security=SSPI;TrustServerCertificate=True";

        using (var coneccao = new SqlConnection(coneccaoString)) {
            coneccao.Open();
            Console.WriteLine("Conectado!");

            using (var comando = new SqlCommand()) {
                comando.Connection = coneccao;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT [Nome], [Email] FROM [Estudantes]";

                var leitor = comando.ExecuteReader();
                while(leitor.Read()) {
                    Console.WriteLine($"{leitor.GetString(0)} - {leitor.GetString(1)}");
                }
            }
        }   
    }
}
