using CRUD.entidades;
using CRUD.infraestructura.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repositorio.Alumno
{
    public class AlumnoCommand
    {
        private readonly alumnosContext _context;

        public AlumnoCommand(alumnosContext context)
        {
            _context = context;
        }

        public async Task<Persona> CreatePersonasAsync(Persona dto)
        {
            _context.Persona.Add(dto);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<Persona> UpdatePersonasAsync(Persona dto)
        {
            var entity = await _context.Persona.FindAsync(dto.Idpersona);

            if (entity == null)
            {
                throw new InvalidOperationException("Persona no encontrada");
            }

            entity.Nombres = dto.Nombres;
            entity.Apellidos = dto.Apellidos;
            entity.Cedula = dto.Cedula;
            entity.Activo = dto.Activo;

            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> DeletePersonaAsync(int id)
        {
            var entity = await _context.Persona.FindAsync(id);
            if (entity == null) return false;

            _context.Persona.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}