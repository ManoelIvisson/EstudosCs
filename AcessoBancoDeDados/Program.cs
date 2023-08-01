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
            // LerViews(conexao);
            // UmParaUm(conexao);
            // ConsultasMultiplas(conexao);
            // SelectIn(conexao);
            // Like(conexao, "de");
            Transaction(conexao);
            ListarCategorias(conexao);
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
    static void UmParaUm(SqlConnection conexao) {
        var sql = "SELECT * FROM [ItemCarreira] INNER JOIN [Curso] ON [ItemCarreira].[CursoId] = [Curso].[Id]";
        var itens = conexao.Query<ItemCarreira, Curso, ItemCarreira>(sql, (itemCarreira, curso)=>{
            itemCarreira.Curso = curso;
            return itemCarreira;
        }, splitOn: "Id");
        foreach (var item in itens) {
            Console.WriteLine(item.Titulo);
        }
    }
    static void UmParaMuitos(SqlConnection conexao) {
        var sql = @"SELECT 
            [Career].[Id],
            [Career].[Title],
            [CareerItem].[CareerId],
            [CareerItem].[Title]
        FROM 
            [Career] 
        INNER JOIN 
            [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
        ORDER BY
            [Career].[Title]";
        var carreiras = new List<Carreira>();
        var itens = conexao.Query<Carreira, ItemCarreira, Carreira>(sql, (carreira, item)=>{
            var car = carreiras.Where(x => x.Id == carreira.Id).FirstOrDefault();
            if (car == null) {
                car = carreira;
                car.Itens.Add(item);
                carreiras.Add(car);
            } else {
                car.Itens.Add(item);
            }
            return carreira;
        }, splitOn: "CarreiraId");
        foreach (var carreira in carreiras) {
            Console.WriteLine(carreira.Titulo);
            foreach (var item in carreira.Itens) {
                Console.WriteLine($" - {item.Titulo}");
        }
        }
    } 
    static void ConsultasMultiplas(SqlConnection conexao) {
        var consultas = "SELECT * FROM [Categoria]; SELECT * FROM [Curso]";

        using(var multi = conexao.QueryMultiple(consultas)) {
            var categorias = multi.Read<Categoria>();
            var cursos = multi.Read<Curso>();

            foreach (var item in categorias) {
                Console.WriteLine(item.Titulo);
            }

            foreach (var item in cursos) {
                Console.WriteLine(item.Titulo);
            }
        }
    }
    static void SelectIn(SqlConnection conexao) {
        var sql = "SELECT * FROM [Categoria] WHERE [Id] In @Id";

        var itens = conexao.Query<Categoria>(sql, new {
            Id = new[] {
                "574d7fb2-7d9c-476d-8623-6d56aae19a8b",
                "d8732e3d-f9c2-4450-b567-97da5852f820"
            }
        });

        foreach (var item in itens){
            Console.WriteLine(item.Titulo);
        }
    }
    static void Like(SqlConnection conexao, string termo) {
        var sql = "SELECT * FROM [Categoria] WHERE [Titulo] LIKE @exp";

        var itens = conexao.Query<Categoria>(sql, new {
            exp = $"%{termo}%"
        });

        foreach (var item in itens){
            Console.WriteLine(item.Titulo);
        }
    }
    static void Transaction(SqlConnection conexao) {
        var categoria = new Categoria();
        categoria.Id = Guid.NewGuid();
        categoria.Titulo = "Fundamentos de ASP.NET";
        categoria.Resumo = "Desenvolva para web com ASP.NET";
        categoria.Url = "ASP-NET";
        categoria.Ordem = 6;
        categoria.Descricao = "Muito bom esse curso mermão";
        categoria.Destaque = false;

        var insertSql = "INSERT INTO [Categoria](Id, Titulo, Resumo, Url, Ordem, Descricao, Destaque) VALUES (@Id, @Titulo, @Resumo, @Url, @Ordem, @Descricao, @Destaque)";

        conexao.Open();
        using(var transaction = conexao.BeginTransaction()) {
            var linhas = conexao.Execute(insertSql, new {categoria.Id, categoria.Titulo, categoria.Resumo, categoria.Url, categoria.Ordem, categoria.Descricao, categoria.Destaque}, transaction);

            transaction.Commit();
            // transaction.Rollback();

            Console.WriteLine($"{linhas} linhas inseridas");
        }
    }
}
