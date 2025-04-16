using Microsoft.AspNetCore.Mvc;
using Tarefa5.Domain.Models;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Service.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController(IEnderecoService enderecoService) : ControllerBase
{
    [HttpGet("{page}/{perPage}")]
    public async Task<IActionResult> Get([FromRoute] int page, [FromRoute] int perPage) => Ok(await enderecoService.BuscarTodosAsync(page, perPage));


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var endereco = await enderecoService.BuscarPorIdAsync(id);
        return endereco == null ? NotFound() : Ok(endereco);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Endereco endereco)
    {
        if (endereco == null)
            return BadRequest("Dados inválidos.");

        var novoEndereco = await enderecoService.CriarAsync(endereco);
        return CreatedAtAction(nameof(Get), new { id = novoEndereco.Id }, novoEndereco);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] Endereco endereco, [FromRoute] Guid id)
    {
        endereco.Id = id;
        return Ok(await enderecoService.AtualizarAsync(endereco));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var sucesso = await enderecoService.DeletarAsync(id);
        return sucesso ? Accepted() : NotFound();
    }
}
