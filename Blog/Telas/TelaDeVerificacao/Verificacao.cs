using Blog.Models;
using Dapper;

namespace Blog.Telas.TelaDeVerificacao {
    public static class Verificacao {
        public static int CarregarTelaUsuario() {
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-= Verificação de Usuário =-=-=-=-=-=-=-=");
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Senha: ");
            var senha = Console.ReadLine();
            var id = VerficarUsuario(email, senha);
            return id;
        }

        public static int CarregarTelaViaSlug(string modelo) {
            Console.Clear();
            Console.WriteLine($"=-=-=-=-=-=-=-= Verificação de {modelo} =-=-=-=-=-=-=-=");
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            var id = VerficarSlug(slug, modelo);
            return id;
        }
        private static int VerficarUsuario(string? email, string? senha){
            var sql = "SELECT [ID] FROM [Usuario] WHERE [Email] = @Email AND [SenhaHash] = @Senha";

            var id = BancoDeDados.Conexao.Query<Usuario>(sql, new {
                Email = email,
                Senha = senha
            });

            if (id.Count() != 0) {
                foreach (var item in id){
                return item.Id;
                }
            } else {
                Console.WriteLine("Usuario não encontrado, por favor tente novamente");
                Console.ReadKey();
                CarregarTelaUsuario();
            }

            return 0;
        }

        private static int VerficarSlug(string? slug, string modelo){
            var sql = "";
            if (modelo == "Categoria") {
                sql = "SELECT [ID] FROM [Categoria] WHERE [Slug] = @Slug";
            } else if (modelo == "Perfil") {
                sql = "SELECT [ID] FROM [Perfil] WHERE [Slug] = @Slug";
            } else {
                sql = "SELECT [ID] FROM [Tag] WHERE [Slug] = @Slug";
            }

            var id = BancoDeDados.Conexao.Query<Categoria>(sql, new {Slug = slug});

            if (id.Count() != 0) {
                foreach (var item in id){
                return item.Id;
                }
            } else {
                Console.WriteLine($"{modelo} não encontrado, por favor tente novamente");
                Console.ReadKey();
                CarregarTelaViaSlug(modelo);
            }

            return 0;
        }
    }
}