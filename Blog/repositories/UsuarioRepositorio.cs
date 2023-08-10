using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories{
    public class UsuarioRepositorio : Repositorio<Usuario> {
        public List<Usuario> LerComPerfis() {
            var sql = @"SELECT [Usuario].*, [Perfil].* FROM [Usuario] 
                        LEFT JOIN [UsuarioPerfil] ON [UsuarioPerfil].[UsuarioId] = [Usuario].[Id]
                        LEFT JOIN [Perfil] ON [UsuarioPerfil].[PerfilId] = [Perfil].[Id]";
            
            var usuarios = new List<Usuario>();

            var itens = BancoDeDados.Conexao.Query<Usuario, Perfil, Usuario>(sql, (usuario, perfil) => {
                var usr = usuarios.FirstOrDefault(x => x.Id == usuario.Id);
                if (usr == null) {
                    usr = usuario;
                    if (perfil != null) {
                        usr.Perfis.Add(perfil);
                    }
                    usuarios.Add(usr);
                } else {
                    usr.Perfis.Add(perfil);
                }
                return usuario;
            }, splitOn: "Id");

            return usuarios;
        }
    }
}