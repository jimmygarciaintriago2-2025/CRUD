using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CRUD.entidades;
using CRUD.infraestructura;
using CRUD.interfaz;

namespace CRUD.repositorio.alumno
{
    public class AlumnoAdonetRepository : IAlumnoRepository
    {
        private readonly ConexionAdonet _conexionAdonet;

        public AlumnoAdonetRepository(ConexionAdonet conexionAdonet)
        {
            _conexionAdonet = conexionAdonet;
        }

        public void Insertar(Persona alumno)
        {
            try
            {
                using (var conn = _conexionAdonet.ObtenerConexion())
                {
                    string query = "INSERT INTO personas (nombres, apellidos, cedula, activo) VALUES (@nombres, @apellidos, @cedula, @activo)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombres", alumno.Nombres);
                        cmd.Parameters.AddWithValue("@apellidos", alumno.Apellidos);
                        cmd.Parameters.AddWithValue("@cedula", alumno.Cedula);
                        cmd.Parameters.AddWithValue("@activo", alumno.Activo);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar alumno con ADO.NET: " + ex.Message);
                throw;
            }
        }

        public List<Persona> ObtenerTodos()
        {
            var listaAlumnos = new List<Persona>();
            try
            {
                using (var conn = _conexionAdonet.ObtenerConexion())
                {
                    string query = "SELECT idpersonas, nombres, apellidos, cedula, activo FROM personas";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaAlumnos.Add(new Persona
                                {
                                    Idpersonas = reader.GetInt32(0),
                                    Nombres = reader.GetString(1),
                                    Apellidos = reader.GetString(2),
                                    Cedula = reader.GetString(3),
                                    Activo = reader.GetBoolean(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar alumnos con ADO.NET: " + ex.Message);
            }
            return listaAlumnos;
        }

        public void Actualizar(Persona alumno)
        {
            try
            {
                using (var conn = _conexionAdonet.ObtenerConexion())
                {
                    string query = "UPDATE personas SET nombres = @nombres, apellidos = @apellidos, cedula = @cedula, activo = @activo WHERE idpersonas = @idpersonas";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idpersonas", alumno.Idpersonas);
                        cmd.Parameters.AddWithValue("@nombres", alumno.Nombres);
                        cmd.Parameters.AddWithValue("@apellidos", alumno.Apellidos);
                        cmd.Parameters.AddWithValue("@cedula", alumno.Cedula);
                        cmd.Parameters.AddWithValue("@activo", alumno.Activo);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar alumno con ADO.NET: " + ex.Message);
                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var conn = _conexionAdonet.ObtenerConexion())
                {
                    string query = "DELETE FROM personas WHERE idpersonas = @idpersonas";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idpersonas", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar alumno con ADO.NET: " + ex.Message);
                throw;
            }
        }
    }
}
