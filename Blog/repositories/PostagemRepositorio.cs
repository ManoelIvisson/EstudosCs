using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories{
    public class PostagemRepositorio : Repositorio<Postagem> {
        public List<Postagem> LerComTags() {
            var sql = @"SELECT [Postagem].*, [Tag].* FROM [Postagem] 
                        LEFT JOIN [PostagemTag] ON [PostagemTag].[PostagemId] = [Postagem].[Id]
                        LEFT JOIN [Tag] ON [PostagemTag].[TagId] = [Tag].[Id]";
            
            var postagens = new List<Postagem>();

            var itens = BancoDeDados.Conexao.Query<Postagem, Tag, Postagem>(sql, (postagem, tag) => {
                var post = postagens.FirstOrDefault(x => x.Id == postagem.Id);
                if (post == null) {
                    post = postagem;
                    if (tag != null) {
                        post.Tags.Add(tag);
                    }
                    postagens.Add(post);
                } else {
                    post.Tags.Add(tag);
                }
                return postagem;
            }, splitOn: "Id");

            return postagens;
        }
    }
}