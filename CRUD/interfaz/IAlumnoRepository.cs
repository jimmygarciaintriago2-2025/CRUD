


using System.Collections.Generic;
using CRUD.entidades;

namespace CRUD.interfaz
{
    public interface IAlumnoRepository
    {
        void Insertar(Persona alumno);
        List<Persona> ObtenerTodos();
        void Actualizar(Persona alumno);
        void Eliminar(int id);
    }
}