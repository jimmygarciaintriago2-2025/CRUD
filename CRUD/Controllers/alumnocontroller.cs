using Microsoft.AspNetCore.Mvc;
using CRUD.repositorio.alumno;
using CRUD.entidades;

namespace CRUD.Controllers
{
    [Route("api/alumnocontroller")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AlumnoQuery _alumnoQuery;
        private readonly AlumnoCommand _alumnoCommand;

        public AlumnoController(AlumnoQuery alumnoQuery, AlumnoCommand alumnoCommand)
        {
            _alumnoQuery = alumnoQuery;
            _alumnoCommand = alumnoCommand;
        }

        // 1. GET: api/alumno
        [HttpGet]
        public IActionResult GetPersonas()
        {
            try
            {
                var personas = _alumnoQuery.ObtenerTodos();
                return Ok(personas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener personas", error = ex.Message });
            }
        }

        // GET: api/alumno/{id}
        [HttpGet("{id}")]
        public IActionResult GetPersonaById(int id)
        {
            try
            {
                var persona = _alumnoQuery.ObtenerPorId(id);
                if (persona == null)
                {
                    return NotFound(new { mensaje = $"No se encontró la persona con ID {id}" });
                }
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener la persona", error = ex.Message });
            }
        }

        // 2. POST: api/alumno
        [HttpPost]
        public IActionResult CreatePersona([FromBody] Persona persona)
        {
            try
            {
                if (persona == null)
                {
                    return BadRequest(new { mensaje = "Datos de persona inválidos" });
                }

                if (string.IsNullOrWhiteSpace(persona.Nombres) || string.IsNullOrWhiteSpace(persona.Apellidos))
                {
                    return BadRequest(new { mensaje = "Nombres y Apellidos son obligatorios" });
                }

                _alumnoCommand.Insertar(persona);
                return Ok(new { mensaje = "Persona insertada correctamente con ADO.NET", data = persona });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al insertar persona", error = ex.Message });
            }
        }

        // 3. PUT: api/alumno/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePersona(int id, [FromBody] Persona persona)
        {
            try
            {
                if (persona == null)
                {
                    return BadRequest(new { mensaje = "Datos de persona inválidos" });
                }

                persona.Idpersonas = id;
                _alumnoCommand.Actualizar(persona);
                return Ok(new { mensaje = "Persona actualizada correctamente con ADO.NET", data = persona });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al actualizar persona", error = ex.Message });
            }
        }

        // Alternativo PUT sin ID en ruta: api/alumno
        [HttpPut]
        public IActionResult UpdatePersonaDirect([FromBody] Persona persona)
        {
            try
            {
                if (persona == null || persona.Idpersonas <= 0)
                {
                    return BadRequest(new { mensaje = "ID de persona inválido para actualización" });
                }

                _alumnoCommand.Actualizar(persona);
                return Ok(new { mensaje = "Persona actualizada correctamente con ADO.NET", data = persona });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al actualizar persona", error = ex.Message });
            }
        }

        // 4. DELETE: api/alumnocontroller/{id} (Borrado Lógico / Inactivación)
        [HttpDelete("{id}")]
        public IActionResult DeletePersona(int id)
        {
            try
            {
                _alumnoCommand.Eliminar(id);
                return Ok(new { mensaje = $"Alumno con ID {id} cambiado a estado inactivo correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al desactivar el alumno", error = ex.Message });
            }
        }
    }
}