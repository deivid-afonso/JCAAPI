using FluentValidation;
using SimpressAPI.Models;

namespace SimpressAPI.Validators
{
    public class ProdutoValidator : AbstractValidator<tblProduto>
    {
        public ProdutoValidator()
        {
            RuleFor(product => product.Nome).NotEmpty().WithMessage("O campo Nome é obrigatório.");
            RuleFor(product => product.Descricao).NotEmpty().WithMessage("O campo Descrição é obrigatório.");
            RuleFor(product => product.Ativo).NotEmpty().WithMessage("O campo Ativo é obrigatório.");
            RuleFor(product => product.Perecivel).NotEmpty().WithMessage("O campo Perecivel é obrigatório.");
            RuleFor(product => product.CategoriaId).NotEmpty().WithMessage("O campo CategoriaId é obrigatório.");
        }
    }
}
