using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

class Program{
    private const string conexaoString = @"Server=.\SqlExpress;Database=Blog;Integrated Security=SSPI; TrustServerCertificate=True";
    static void Main(string [] args){
        LerUsuarios();
    }

    public static void LerUsuarios(){
        using(var conexao = new SqlConnection(conexaoString)) {
            var usuarios = conexao.GetAll<Usuario>();

            foreach (var usuario in usuarios){
                Console.WriteLine($"Nome: {usuario.Nome} Email: {usuario.Email}");
            }
        }
    }
}

