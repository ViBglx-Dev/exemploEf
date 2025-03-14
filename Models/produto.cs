namespace ExemploEF.Models
{
    public class produto
    {
        public Guid produtoId { get; set; }    
       public string nome { get; set; }
       public int estoque { get; set; }
        public Guid categoriaid { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
