using Microsoft.Data.SqlClient;

namespace Blog {
    public static class BancoDeDados {
        static BancoDeDados() {
            Conexao = new SqlConnection();
        }
        public static SqlConnection Conexao;
    }
}