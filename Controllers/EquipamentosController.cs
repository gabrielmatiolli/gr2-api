using Microsoft.AspNetCore.Mvc;
using gr2_api.Controllers.ViewModels.Response;
using gr2_api.Controllers.ViewModels.Request;
using gr2_api.Interfaces.Services;

namespace gr2_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentosService _equipamentosService;

        public EquipamentosController(IEquipamentosService equipamentosService)
        {
            _equipamentosService = equipamentosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EquipamentosResponseViewModel>>> GetAllEquipamentos()
        {
            var equipamentos = await _equipamentosService.GetAllEquipamentosAsync();
            if (!equipamentos.Success) return BadRequest(equipamentos.Error);

            return Ok(equipamentos);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipamentosResponseViewModel>> GetEquipamentoById(int id)
        {
            var equipamento = await _equipamentosService.GetEquipamentoByIdAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            return Ok(equipamento);
        }

        [HttpPost]
        public async Task<ActionResult> AddEquipamento([FromBody]EquipamentoRequestViewModel request)
        {
            var result = await _equipamentosService.AddEquipamentoAsync(request);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetEquipamentoById), new { id = result.Data.Id }, result.Data);
            }
            return BadRequest(result.Error);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEquipamento(int id, EquipamentoRequestViewModel request)
        {

            var existingEquipamento = await _equipamentosService.GetEquipamentoByIdAsync(id);
            if (existingEquipamento == null)
            {
                return NotFound();
            }

            await _equipamentosService.UpdateEquipamentoAsync(request);
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