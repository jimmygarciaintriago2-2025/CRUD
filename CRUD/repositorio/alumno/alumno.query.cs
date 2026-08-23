using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CRUD.entidades;
using CRUD.infraestructura;

namespace CRUD.repositorio.alumno
{
    public class AlumnoQuery
    {
        private readonly ConexionAdonet _conexionAdonet;

        public AlumnoQuery(ConexionAdonet conexionAdonet)
        {
            _conexionAdonet = conexionAdonet;
        }

        public List<Persona> ObtenerTodos()
        {
            var lista = new List<Persona>();
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
                                lista.Add(new Persona
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
                Console.WriteLine("Error: " + ex.Message);
            }
            return lista;
        }
    }
}