namespace AcessoBancoDeDados {
    public class Categoria {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Resumo { get; set; }
        public string? Url { get; set; }
        public int Ordem { get; set; }
        public string? Descricao { get; set; }
        public bool Destaque { get; set; }
    } 
}
