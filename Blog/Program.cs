using Blog;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

class Program{
    private const string conexaoString = @"Server=.\SqlExpress;Database=Blog;Integrated Security=SSPI; TrustServerCertificate=True";
    static void Main(string [] args){
        BancoDeDados.Conexao = new SqlConnection(conexaoString);
        BancoDeDados.Conexao.Open();
        Menu.Inicio();
        BancoDeDados.Conexao.Close();
    }

    public static void LerUsuarios(SqlConnection conexao){
        var repositorio = new UsuarioRepositorio();
        var usuarios = repositorio.LerComPerfis();

        foreach (var usuario in usuarios){
            Console.WriteLine($"Nome: {usuario.Nome} Email: {usuario.Email}");
            foreach (var perfil in usuario.Perfis) {
                Console.WriteLine($" - {perfil.Nome}");
            }
        }
    }

    public static void LerUsuario(SqlConnection conexao) {
        var repositorio = new Repositorio<Usuario>();
        var usuario = repositorio.Get(2);

        Console.WriteLine(usuario.Nome);
    }

    public static void LerTag(SqlConnection conexao) {
        var repositorio = new Repositorio<Tag>();
        var tag = repositorio.Get(1);

        Console.WriteLine(tag.Nome);
    }

    public static void CriarTag(SqlConnection conexao) {
        var repositorio = new Repositorio<Tag>();
        var tag = new Tag() {
            Nome = "ASP.NET",
            Slug = "asp-net"
        };

        repositorio.Criar(tag);
    }

    public static void CriarUsuario(SqlConnection conexao) {
        var repositorio = new Repositorio<Usuario>();
        var usuario = new Usuario() {
            Nome = "Yasmin da Silva",
            Email = "yasminsilva@exemplo.com",
            SenhaHash = "hash",
            Bio = "Linda demais",
            Imagem = "https://...",
            Slug = "yasmin-silva"
        };

        repositorio.Criar(usuario);
    }

    public static void DeletarUsuario(SqlConnection conexao){
        var repositorio = new Repositorio<Usuario>();
        var usuario = repositorio.Get(4);

        repositorio.Deletar(usuario);    
    }
}

    // public static void CriarUsuario() {
    //     var usuario = new Usuario() {
    //         Nome = "Yasmin da Silva",
    //         Email = "yasminsilva@exemplo.com",
    //         SenhaHash = "hash",
    //         Bio = "Linda demais",
    //         Imagem = "https://...",
    //         Slug = "yasmin-silva"
    //     };

    //     using(var conexao = new SqlConnection(conexaoString)) {
    //         conexao.Insert<Usuario>(usuario);
    //         Console.WriteLine($"Bem vindo {usuario.Nome}, seu cadastro foi feito com sucesso");
    //     }
    // }

    // public static void AtualizarUsuario() {
    //     var usuario = new Usuario() {
    //         Id = 2,
    //         Nome = "Yasmin Cristine",
    //         Email = "yasminsilva@exemplo.com",
    //         SenhaHash = "hash"
    //         Bio = "Minha Irmã",
    //         Imagem = "https://...",
    //         Slug = "yasmin-cristine"
    //     };

    //     using(var conexao = new SqlConnection(conexaoString)) {
    //         conexao.Update<Usuario>(usuario);
    //         Console.WriteLine($"Seu cadastro foi atualizado com sucesso");
    //     }
    // }

    // public static void DeletarUsuario() {
    //     using(var conexao = new SqlConnection(conexaoString)) {
    //         var usuario = conexao.Get<Usuario>(2);
    //         conexao.Delete<Usuario>(usuario);
    //         Console.WriteLine($"Seu cadastro foi deletado com sucesso");
    //     }
    // }


