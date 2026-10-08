using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanicaApi.data;
using ProjetoMecanicaApi.models;

namespace ProjetoMecanicaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamento()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> CriarAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return Ok("Agendamento salvo com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult<Agendamento>> PutAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            await _context.SaveChangesAsync();

            return Ok(agendamento);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
                return NotFound("Agendamento não encontrado.");

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return Ok("Agendamento cancelado com sucesso!");
        }
    }
}