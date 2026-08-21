using Microsoft.AspNetCore.Mvc;
using CRUD.Repositorio.Alumno;
using CRUD.entidades;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class alumnocontroller : ControllerBase
    {
        private readonly AlumnoQuery _alumnoQuery;
        private readonly AlumnoCommand _alumnoCommand;

        public alumnocontroller(AlumnoQuery alumnoQuery, AlumnoCommand alumnoCommand)
        {
            _alumnoQuery = alumnoQuery;
            _alumnoCommand = alumnoCommand;
        }

        // GET: api/alumnocontroller
        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            var personas = await _alumnoQuery.GetPersonasAsync();
            return Ok(personas);
        }

        // POST: api/alumnocontroller
        [HttpPost]
        public async Task<IActionResult> CreatePersona([FromBody] Persona dto)
        {
            var nuevaPersona = await _alumnoCommand.CreatePersonasAsync(dto);
            return Ok(nuevaPersona);
        }
    }
}