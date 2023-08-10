using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories {
    public class Repositorio<T> where T : class {
        public IEnumerable<T> Get() 
            => BancoDeDados.Conexao.GetAll<T>();

        public T Get(int id)
            =>  BancoDeDados.Conexao.Get<T>(id);

        public void Criar(T modelo)
            => BancoDeDados.Conexao.Insert<T>(modelo);
        
        public void Atualizar(T modelo)
            => BancoDeDados.Conexao.Update<T>(modelo);
        
        public void Deletar(T modelo)
            => BancoDeDados.Conexao.Delete<T>(modelo);
        
        public void Deletar(int id){
            T modelo = BancoDeDados.Conexao.Get<T>(id);
            BancoDeDados.Conexao.Delete<T>(modelo);
        }
    }
}