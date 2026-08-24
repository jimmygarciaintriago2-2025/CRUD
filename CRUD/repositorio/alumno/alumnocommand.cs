using System;
using Microsoft.Data.SqlClient;
using CRUD.entidades;
using CRUD.infraestructura;

namespace CRUD.repositorio.alumno
{
    public class AlumnoCommand
    {
        private readonly ConexionAdonet _conexionAdonet;

        public AlumnoCommand(ConexionAdonet conexionAdonet)
        {
            _conexionAdonet = conexionAdonet;
        }

        public void Insertar(Persona persona)
        {
            using (var conn = _conexionAdonet.ObtenerConexion())
            {
                string query = "INSERT INTO personas (nombres, apellidos, cedula, activo) VALUES (@nombres, @apellidos, @cedula, @activo)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombres", persona.Nombres ?? "");
                    cmd.Parameters.AddWithValue("@apellidos", persona.Apellidos ?? "");
                    cmd.Parameters.AddWithValue("@cedula", persona.Cedula ?? "");
                    cmd.Parameters.AddWithValue("@activo", persona.Activo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(Persona persona)
        {
            using (var conn = _conexionAdonet.ObtenerConexion())
            {
                string query = "UPDATE personas SET nombres = @nombres, apellidos = @apellidos, cedula = @cedula, activo = @activo WHERE idpersonas = @idpersonas";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idpersonas", persona.Idpersonas);
                    cmd.Parameters.AddWithValue("@nombres", persona.Nombres ?? "");
                    cmd.Parameters.AddWithValue("@apellidos", persona.Apellidos ?? "");
                    cmd.Parameters.AddWithValue("@cedula", persona.Cedula ?? "");
                    cmd.Parameters.AddWithValue("@activo", persona.Activo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int id)
        {
            // Borrado lógico / Inactivación (Soft Delete)
            using (var conn = _conexionAdonet.ObtenerConexion())
            {
                string query = "UPDATE personas SET activo = 0 WHERE idpersonas = @idpersonas";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idpersonas", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
