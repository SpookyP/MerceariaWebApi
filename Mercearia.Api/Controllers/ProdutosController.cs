using Mercearia.Application.DTOs;
using Mercearia.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mercearia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;
        // Injetamos o SERVIÇO, não o Repositório
        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponse>>> Get()
        {
            var produtos = await _service.ObterTodosAsync();
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoResponse>> Get(int id)
        {
            var produto = await _service.ObterPorIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoResponse>> Post(CriarProdutoRequest request)
        {
            // O Controller apenas passa o pedido para o serviço
            var resposta = await _service.CriarAsync(request);
            return CreatedAtAction(nameof(Get), new { id = resposta.Id }, resposta);
        }
    }
}
