using Microsoft.AspNetCore.Mvc;
using gr2_api.Services;
using gr2_api.Models;

namespace gr2_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentosController : ControllerBase
    {
        private readonly EquipamentosService _equipamentosService;

        public EquipamentosController(EquipamentosService equipamentosService)
        {
            _equipamentosService = equipamentosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equipamento>>> GetAllEquipamentos()
        {
            var equipamentos = await _equipamentosService.GetAllEquipamentosAsync();
            return Ok(equipamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipamento>> GetEquipamentoById(int id)
        {
            var equipamento = await _equipamentosService.GetEquipamentoByIdAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            return Ok(equipamento);
        }

        [HttpPost]
        public async Task<ActionResult> AddEquipamento(Equipamento equipamento)
        {
            await _equipamentosService.AddEquipamentoAsync(equipamento);
            return CreatedAtAction(nameof(GetEquipamentoById), new { id = equipamento.Id }, equipamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEquipamento(int id, Equipamento equipamento)
        {
            if (id != equipamento.Id)
            {
                return BadRequest();
            }

            var existingEquipamento = await _equipamentosService.GetEquipamentoByIdAsync(id);
            if (existingEquipamento == null)
            {
                return NotFound();
            }

            await _equipamentosService.UpdateEquipamentoAsync(equipamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEquipamento(int id)
        {
            var existingEquipamento = await _equipamentosService.GetEquipamentoByIdAsync(id);
            if (existingEquipamento == null)
            {
                return NotFound();
            }

            await _equipamentosService.DeleteEquipamentoAsync(id);
            return NoContent();
        }
    }
}