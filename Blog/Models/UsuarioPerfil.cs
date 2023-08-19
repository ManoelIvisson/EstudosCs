using Dapper.Contrib.Extensions;

namespace Blog.Models {
    [Table("UsuarioPerfil")]
    
    class UsuarioPerfil {
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }
    }
}