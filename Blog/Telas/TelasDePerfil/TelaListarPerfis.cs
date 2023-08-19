using Blog.Models;
using Blog.Repositories;

namespace Blog.Telas.TelasDePerfil {
    public static class TelaListarperfis {
        public static void ListarPerfis(){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Lista de Perfis =-=-=-=-=-=-=-=");
            var repositorio = new Repositorio<Perfil>();
            var perfis = repositorio.Get();
            foreach (var usuario in perfis) {
                Console.WriteLine($" {usuario.Id} - {usuario.Nome} - {usuario.Slug}");
            }
            Console.ReadKey();
        }
    }
}
