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
                    cmd.Parameters.AddWithValue("@nombres", persona.Nombres);
                    cmd.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                    cmd.Parameters.AddWithValue("@cedula", persona.Cedula);
                    cmd.Parameters.AddWithValue("@activo", persona.Activo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
