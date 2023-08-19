using Blog.Models;
using Blog.Repositories;
using Blog.Telas.TelaDeVerificacao;
using Dapper;

namespace Blog.Telas.TelasDevinculo {
   public static class VinculoUsuarioPerfil {
        public static void VuncularUsuarioPerfil(int usuarioId = 0, int perfilId = 0) {
            Console.Clear();

            if (usuarioId == 0) {
                usuarioId = Verificacao.CarregarTelaUsuario();
            }

            if (perfilId == 0) {
                perfilId = Verificacao.CarregarTelaViaSlug("Perfil");
            } 

            var sql = "INSERT INTO [UsuarioPerfil] VALUES (@UsuarioId, @PerfilId)";
            var repositorio = new Repositorio<UsuarioPerfil>();
            
            var vinculo = BancoDeDados.Conexao.Query<UsuarioPerfil>(sql, new {
                UsuarioId = usuarioId,
                PerfilId = perfilId
            });

            foreach (var item in vinculo) {
                repositorio.Criar(item);
            }

            Console.WriteLine("Vinculo criado com sucesso");
            Console.ReadKey();
            Menu.Inicio();
        }
   }
}