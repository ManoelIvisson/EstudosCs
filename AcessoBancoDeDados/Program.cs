using AcessoBancoDeDados;
using Dapper;
using Microsoft.Data.SqlClient;
class Program {
    static void Main(string[] args){
        const string conexaoString = @"Server=.\SQLEXPRESS;Database=Balta;Integrated Security=SSPI;TrustServerCertificate=True";

        using (var conexao = new SqlConnection(conexaoString)) {
            Console.WriteLine("Conectado!");

            // CriarVariasCategorias(conexao);
            // DeletarCategorias(conexao);
            // AtualizarCategorias(conexao);
            // LerProcedures(conexao);
            // ExecutarScalar(conexao);
            // ListarCategorias(conexao);
            // CriarCategorias(conexao);
            LerViews(conexao);
        }
    }   

    static void ListarCategorias(SqlConnection conexao) {
        var categorias = conexao.Query<Categoria>("SELECT [Id], [Titulo], [Resumo] FROM [Categoria]");
        foreach (var item in categorias) {
            Console.WriteLine($"{item.Id} - {item.Titulo} - {item.Resumo}");
        }
    }
    static void CriarCategorias(SqlConnection conexao) {
        var categoria = new Categoria();
        categoria.Id = Guid.NewGuid();
        categoria.Titulo = "Celulares móveis";
        categoria.Resumo = "Resumindo, celulares são móveis hoje em dia";
        categoria.Url = "celular-movel";
        categoria.Ordem = 2;
        categoria.Descricao = "Muito bom esse curso";
        categoria.Destaque = false;

        var insertSql = "INSERT INTO [Categoria](Id, Titulo, Resumo, Url, Ordem, Descricao, Destaque) VALUES (@Id, @Titulo, @Resumo, @Url, @Ordem, @Descricao, @Destaque)";

        var linhas = conexao.Execute(insertSql, new {categoria.Id, categoria.Titulo, categoria.Resumo, categoria.Url, categoria.Ordem, categoria.Descricao, categoria.Destaque});

        Console.WriteLine($"{linhas} linhas inseridas");
    }
    static void AtualizarCategorias(SqlConnection conexao) {
        var atualizar = "UPDATE [Categoria] SET [Titulo]=@titulo WHERE [Id]=@id";
        var linhas = conexao.Execute(atualizar, new {id = new Guid("14464b98-910b-4acf-ada6-c1b673a5a4e4"), titulo = "Celulares e computadores"});

        Console.WriteLine($"{linhas} registros atualizados");
    }
    static void DeletarCategorias(SqlConnection conexao){
        var deletar = "DELETE [Categoria] WHERE [Id]=@id";
        var linhas = conexao.Execute(deletar, new {id = new Guid("777dd6bb-d03d-473c-8daf-402b378107d5")});

        Console.WriteLine($"{linhas} linhas deletadas");
    }
    static void CriarVariasCategorias(SqlConnection conexao) {
        var categoria = new Categoria();
        categoria.Id = Guid.NewGuid();
        categoria.Titulo = "Celulares móveis";
        categoria.Resumo = "Resumindo, celulares são móveis hoje em dia";
        categoria.Url = "celular-movel";
        categoria.Ordem = 2;
        categoria.Descricao = "Muito bom esse curso";
        categoria.Destaque = false;

        var categoria2 = new Categoria();
        categoria2.Id = Guid.NewGuid();
        categoria2.Titulo = "Frontend 2023";
        categoria2.Resumo = "Seja um desenvolvedor frontend hoje";
        categoria2.Url = "frontend-2023";
        categoria2.Ordem = 3;
        categoria2.Descricao = "Fique sempre na frente com o frontend 2023";
        categoria2.Destaque = true;

        var insertSql = "INSERT INTO [Categoria](Id, Titulo, Resumo, Url, Ordem, Descricao, Destaque) VALUES (@Id, @Titulo, @Resumo, @Url, @Ordem, @Descricao, @Destaque)";

        var linhas = conexao.Execute(insertSql, new[] { 
            new {categoria.Id, categoria.Titulo, categoria.Resumo, categoria.Url, categoria.Ordem, categoria.Descricao, categoria.Destaque}, 
            new {categoria2.Id, categoria2.Titulo, categoria2.Resumo, categoria2.Url, categoria2.Ordem, categoria2.Descricao, categoria2.Destaque}
            });

        Console.WriteLine($"{linhas} linhas inseridas");
    }
    static void ExecutarProcedures(SqlConnection conexao) {
        var procedure = "[spDeletarAluno]";
        var parametros = new {IdEstudante = "979327f5-21cf-4277-974a-16a398069e0c"};
        var linhas = conexao.Execute(procedure, parametros, commandType: System.Data.CommandType.StoredProcedure);

        Console.WriteLine($"{linhas} linhas afetadas");
    }
    static void LerProcedures(SqlConnection conexao) {
        var procedure = "[spCursosPorCategoria]";
        var parametros = new { CategoriaId = "a5854089-1545-43f1-9264-35daf228b1fe"};
        var cursos = conexao.Query(procedure, parametros, commandType: System.Data.CommandType.StoredProcedure);

        foreach (var item in cursos){
            Console.WriteLine($"{item.Id}");
        }
    }
    static void ExecutarScalar(SqlConnection conexao) {
        var categoria = new Categoria();
        categoria.Id = Guid.NewGuid();
        categoria.Titulo = "Fundamentos de Python";
        categoria.Resumo = "Pai tá on";
        categoria.Url = "fundamentos-python";
        categoria.Ordem = 5;
        categoria.Descricao = "Python é agro, Python é top, Python é pop!";
        categoria.Destaque = false;

        var insertSql = "INSERT INTO [Categoria] (Id, Titulo, Resumo, Url, Ordem, Descricao, Destaque) OUTPUT inserted.[Id] VALUES (NEWID(), @Titulo, @Resumo, @Url, @Ordem, @Descricao, @Destaque)";

        var id = conexao.ExecuteScalar<Guid>(insertSql, new {categoria.Titulo, categoria.Resumo, categoria.Url, categoria.Ordem, categoria.Descricao, categoria.Destaque});

        Console.WriteLine($"O id da categoria {categoria.Titulo} é {id}");
    }
    static void LerViews(SqlConnection conexao) {
        var view = "SELECT * FROM [vwCategorias]";
        var categorias = conexao.Query<Categoria>(view);
        foreach (var item in categorias){
            Console.WriteLine($"Id: {item.Id} - Título: {item.Titulo} - Resumo: {item.Resumo}");
        }
    }
}
