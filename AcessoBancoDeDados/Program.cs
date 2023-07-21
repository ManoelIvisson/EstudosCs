using AcessoBancoDeDados;
using Dapper;
using Microsoft.Data.SqlClient;
class Program {
    static void Main(string[] args){
        const string conexaoString = @"Server=.\SQLEXPRESS;Database=Balta;Integrated Security=SSPI;TrustServerCertificate=True";

        var categoria = new Categoria();
        categoria.Id = Guid.NewGuid();
        categoria.Titulo = "Celulares móveis";
        categoria.Resumo = "Resumindo, celulares são móveis hoje em dia";
        categoria.Url = "celular-movel";
        categoria.Ordem = 2;
        categoria.Descricao = "Muito bom esse curso";
        categoria.Destaque = false;

        var  insertSql = "INSERT INTO [Categoria](Id, Titulo, Resumo, Url, Ordem, Descricao, Destaque) VALUES (@Id, @Titulo, @Resumo, @Url, @Ordem, @Descricao, @Destaque)";

        using (var conexao = new SqlConnection(conexaoString)) {
            Console.WriteLine("Conectado!");

            var linhas = conexao.Execute(insertSql, new {categoria.Id, categoria.Titulo, categoria.Resumo, categoria.Url, categoria.Ordem, categoria.Descricao, categoria.Destaque});

            Console.WriteLine($"{linhas} linhas inseridas");

            var categorias = conexao.Query<Categoria>("SELECT [Id], [Titulo], [Resumo] FROM [Categoria]");
            foreach (var item in categorias) {
                Console.WriteLine($"{item.Id} - {item.Titulo} - {item.Resumo}");
            }
        }
    }   
}

