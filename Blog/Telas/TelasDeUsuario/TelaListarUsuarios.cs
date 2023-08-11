using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Telas.TelasDeUsuario {
    public static class TelaListarUsuario {
        public static void ListarUsuarios(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Lista de Usuários =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Usuario>();
            var usuarios = repositorio.Get();
            foreach (var usuario in usuarios) {
                Console.WriteLine($" {usuario.Id} - {usuario.Nome} - {usuario.Email} - {usuario.Bio}");
            }
        }

        public static void ListarUsuariosComPerfis(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Lista de Usuários e Perfis =-=-=-=-=-=-=-=");
            var repositorio = new UsuarioRepositorio();
            var usuarios = repositorio.LerComPerfis();

            foreach (var usuario in usuarios) {
                Console.Write($" {usuario.Nome}, {usuario.Email}, {usuario.Bio}");
                foreach (var perfis in usuario.Perfis) {
                    Console.Write($", {perfis.Nome} ({perfis.Slug})");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}