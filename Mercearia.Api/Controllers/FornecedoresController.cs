using Azure.Core;
using Mercearia.Application.DTOs;
using Mercearia.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Mercearia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorService _service;
        // Injetamos o SERVIÇO, não o Repositório
        public FornecedoresController(IFornecedorService service)
        {
            _service = service;
        }
        [HttpGet("Details/")]
        public async Task<ActionResult<IEnumerable<FornecedorResponse>>> Get()
        {
            var fornecedores = await _service.ObterTodosAsync();
            return Ok(fornecedores);
        }
        [HttpGet("Details/{id}")]
        public async Task<ActionResult<FornecedorResponse>> Get(Guid id)
        {
            var fornecedor = await _service.ObterPorIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }
            return Ok(fornecedor);
        }
        [HttpPost("Create/")]
        public async Task<ActionResult<FornecedorResponse>> Post(CriarFornecedorRequest request)
        {
            // O Controller apenas passa o pedido para o serviço
            var resposta = await _service.CriarAsync(request);
            return CreatedAtAction(nameof(Get), new { id = resposta.Id }, resposta);
        }
        [HttpPatch("Delete/{id}")]
        public async Task<ActionResult<FornecedorResponse>> Patch(Guid id)
        {
            var fornecedor = await _service.ObterPorIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }
            var resposta = await _service.ApagarAsync(id);
            return Ok(resposta);
        }
        [HttpPatch("Edit/{id}")]
        public async Task<ActionResult<FornecedorResponse>> Put(Guid id, EditarFornecedorRequest request)
        {
            var fornecedor = await _service.ObterPorIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }
            var resposta = await _service.EditarAsync(id, request);
            return Ok(resposta);
        }
    }
}
