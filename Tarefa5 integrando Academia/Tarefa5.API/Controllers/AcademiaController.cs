using Microsoft.AspNetCore.Mvc;
using Tarefa5.Application.Services;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;

namespace Tarefa5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademiaController : ControllerBase
    {
        private readonly IAcademiaService _academiaService;

        public AcademiaController(IAcademiaService academiaService)
        {
            _academiaService = academiaService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var academias = await _academiaService.BuscarTodosAsync();
            return Ok(academias);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var academia = await _academiaService.BuscarPorIdAsync(id);
            if (academia == null)
            {
                return NotFound();
            }
            return Ok(academia);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Academia academia)
        {
            var newAcademia = await _academiaService.CriarAsync(academia);
            return CreatedAtAction(nameof(Get), new { id = newAcademia.Id }, newAcademia);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Academia academia)
        {
            if (id != academia.Id)
            {
                return BadRequest();
            }
            var updatedAcademia = await _academiaService.AtualizarAsync(academia);
            return Ok(updatedAcademia);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _academiaService.DeletarAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    } 
}
