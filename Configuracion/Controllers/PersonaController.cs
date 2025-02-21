using Entidades;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Configuracion.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersona _persona;

        public PersonaController(IPersona personaR)
        {
            _persona = personaR;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona personas)
        {
            int id = await _persona.InsertarPersona(personas);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            var personas = await _persona.ObtenerPorId(id);
            return Ok(personas);

        }
    }
}
