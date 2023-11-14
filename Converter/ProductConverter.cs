using SimpressAPI.Dto;
using SimpressAPI.Models;

namespace SimpressAPI.Converter
{
    public class ProductConverter
    {
        public tblProduto? ConvertToProduct(ProdutoDto produto)
        {

            var newProduct = new tblProduto
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo,
                Perecivel = produto.Perecivel,
                CategoriaId = produto.CategoriaId
            };

            return newProduct;
        }

    }

    
}
