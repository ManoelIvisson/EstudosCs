namespace AcessoBancoDeDados{
    public class Carreira {
        public Carreira() {
            Itens = new List<ItemCarreira>();
        }

        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public List<ItemCarreira> Itens { get; set; }
    }
}
