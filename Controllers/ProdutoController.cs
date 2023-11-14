using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimpressAPI.Data;
using SimpressAPI.Dto;
using SimpressAPI.Models;
using SimpressAPI.Services;

namespace SimpressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly ProdutoService _produtoService;

       // private readonly IValidator<ProdutoDto> _produtoValidator;


        public ProdutoController(ApiDbContext context, ProdutoService productService/*, IValidator<ProdutoDto> produtoValidator*/)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _produtoService = productService ?? throw new ArgumentNullException(nameof(productService));
            //_produtoValidator = produtoValidator ?? throw new ArgumentNullException(nameof(produtoValidator));


        }

        [HttpGet(Name = "Get all products")]
        public IActionResult GetAllProducts()
        {
            return Ok(_context.Produtos.ToList());
        }

        [HttpGet("{id}", Name = "Find product by id")]
        public IActionResult FindById(int id)
        {
            var produto = _produtoService.GetProductById(id);

            return Ok(produto);
        }

        [HttpPut(Name = "Insert new product")]
        public IActionResult Put([FromBody] ProdutoDto product)
        {

            try
            {
                _produtoService.AddProduct(product);

                return Ok("Produto cadastrado com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados");
            }
        }

        [HttpPost(Name = "Update product")]
        public IActionResult Update([FromBody] ProdutoDto product)
        {
            _produtoService.UpdateProduct(product);

            return Ok("Produto atualizado com sucesso");
        }

        [HttpDelete("{id}", Name = "Delete product by id")]
        public IActionResult Delete(int id)
        {
            _produtoService.DeleteProduct(id);

            return Ok("Produto deletado com sucesso!");
        }
    }
}
