using Microsoft.AspNetCore.Mvc;
using Tarefa5.Application.Services;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;

namespace Tarefa5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AparelhoController : ControllerBase
    {
        private readonly IAparelhoService _aparelhoService;
        public AparelhoController(IAparelhoService aparelhoService)
        {
            _aparelhoService = aparelhoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var aparelho = await _aparelhoService.BuscarTodosAsync();
            return Ok(aparelho);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var aparelho = await _aparelhoService.BuscarPorIdAsync(id);
            if (aparelho == null)
            {
                return NotFound();
            }
            return Ok(aparelho);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Aparelho aparelho)
        {
            var newAparelho = await _aparelhoService.CriarAsync(aparelho);
            return CreatedAtAction(nameof(Get), new { id = newAparelho.Id }, newAparelho);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Aparelho aparelho)
        {
            if (id != aparelho.Id)
            {
                return BadRequest();
            }
            var updatedAparelho = await _aparelhoService.AtualizarAsync(aparelho);
            return Ok(updatedAparelho);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _aparelhoService.DeletarAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
