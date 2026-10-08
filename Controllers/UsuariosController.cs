
using Microsoft.AspNetCore.Mvc;
using ProjetoMecanicaApi.data;
using ProjetoMecanicaApi.models;


namespace ProjetoMecanicaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;


        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("login")]
        public IActionResult Login(Users usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(
                u => u.Usuario == usuario.Usuario &&
                     u.Senha == usuario.Senha
            );


            if (user == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }


            return Ok(user);
        }
    }
}