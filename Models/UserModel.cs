using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace JCAApi.Models
{
    public partial class UserModel
    {
        public UserModel? user;

        public UserModel()
        {

        }
        public UserModel(UserModel user)
        {
            this.Nome = user.Nome;
            this.Email = user.Email;
            this.Ativo = user.Ativo;
            this.Permissao = user.Permissao;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public bool Ativo { get; set; }

        public bool Permissao { get; set; }
        public ClaimsIdentity? Role { get; internal set; }
        public ClaimsIdentity? Username { get; internal set; }
    }
}