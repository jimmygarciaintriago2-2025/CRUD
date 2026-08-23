using Microsoft.AspNetCore.Mvc;
using CRUD.repositorio.alumno;
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
        public IActionResult GetPersonas()
        {
            var personas = _alumnoQuery.ObtenerTodos();
            return Ok(personas);
        }

        // POST: api/alumnocontroller
        [HttpPost]
        public IActionResult CreatePersona([FromBody] Persona persona)
        {
            _alumnoCommand.Insertar(persona);
            return Ok(new { mensaje = "Persona insertada correctamente con ADO.NET" });
        }
    }
}