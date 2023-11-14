using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpressAPI.Models
{
    public partial class tblProduto
    {
        public tblProduto? produto;

        public tblProduto()
        {
            
        }
        public tblProduto(tblProduto produto)
        {
            this.Nome = produto.Nome;
            this.Descricao = produto.Descricao;
            this.Ativo = produto.Ativo;
            this.Perecivel = produto.Perecivel;
            this.CategoriaId = produto.CategoriaId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string? Nome { get; set; }
       
        public string? Descricao { get; set; }
        
        public bool Ativo { get; set; }
      
        public bool Perecivel { get; set; }


        [ForeignKey("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
        public tblCategoriaProduto Categoria { get; set; }
    }
}
