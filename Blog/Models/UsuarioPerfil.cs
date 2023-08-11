using Dapper.Contrib.Extensions;

namespace Blog.Models {
    [Table("UsuarioPerfil")]
    class UsuarioPerfil {
        public UsuarioPerfil() {
            UsuarioId = new List<int>();
            PerfilId = new List<int>();
        }
        public List<int> UsuarioId { get; set; }
        public List<int> PerfilId { get; set; }
    }
}