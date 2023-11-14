namespace SimpressAPI.Dto
{
    public class ProdutoDto
    {
        public int ProductId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }     
        public bool Perecivel { get; set; } 
        public int CategoriaId { get; set; }

    }
}
