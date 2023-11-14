using SimpressAPI.Converter;
using SimpressAPI.Data;
using SimpressAPI.Dto;
using SimpressAPI.Models;
using System;

namespace SimpressAPI.Services
{
    public class ProdutoService
    {
        private readonly ApiDbContext _context;
        private readonly ProductConverter _converter;

        public ProdutoService(ApiDbContext context, ProductConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public void UpdateProduct(ProdutoDto product)
        {
            tblProduto? existingProduct = verifyProduct(product);
            verifyCategory(product);

            _converter.ConvertToProduct(product);

            _context.SaveChanges();
        }

        public tblProduto GetProductById(int id)
        {
            verifyProductById(id);
            return _context.Produtos.Find(id);
        }

        public void AddProduct(ProdutoDto product)
        {
            try {
                tblProduto? tblProduto = _converter.ConvertToProduct(product);
                _context.Produtos.Add(tblProduto);
                _context.SaveChanges();
            }
            catch (InvalidOperationException e) { 
                throw e;
            }
        }

        public void DeleteProduct(int id)
        {
            verifyProductById(id);

            _context.Produtos.Remove(_context.Produtos.Find(id));
            _context.SaveChanges();
        }

        private void verifyCategory(ProdutoDto product)
        {
            var existingCategory = _context.Categorias.Find(product.CategoriaId);
            if (existingCategory == null)
            {
                throw new InvalidOperationException($"Categoria com ID {product.CategoriaId} não encontrada.");
            }
        }

        private tblProduto verifyProduct(ProdutoDto product)
        {
            var existingProduct = _context.Produtos.Find(product.ProductId);
            if (existingProduct == null)
            {
                throw new InvalidOperationException($"Produto com ID {product.ProductId} não encontrado.");
            }

            return existingProduct;
        }

        private tblProduto verifyProductById(int id)
        {
            var existingProduct = _context.Produtos.Find(id);
            if (existingProduct == null)
            {
                throw new InvalidOperationException($"Produto com ID {existingProduct.ProductId} não encontrado.");
            }

            return existingProduct;
        }
    }
}
