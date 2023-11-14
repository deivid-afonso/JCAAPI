using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpressAPI.Models
{
    public partial class tblCategoriaProduto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
