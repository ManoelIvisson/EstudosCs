using Dapper.Contrib.Extensions;

namespace Blog.Models {
    [Table("PostagemTag")]
    class PostagemTag {
        public int PostagemId { get; set; }
        public int TagId { get; set; }
    }
}