using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanicaApi.data;
using ProjetoMecanicaApi.models;

namespace ProjetoMecanicaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculo()
        {
            return await _context.Veiculos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CriarVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return Ok("Veículo criado com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult<Veiculo>> PutVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();

            return Ok(veiculo);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
                return NotFound("Veículo não encontrado.");

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return Ok("Veículo excluído com sucesso!");
        }
    }
}
