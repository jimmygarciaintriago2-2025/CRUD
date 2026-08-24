using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using dashboard.Models;

namespace dashboard.Services
{
    public class AlumnoApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        public string BaseUrl { get; private set; }
        public string SqlConnectionString { get; set; } = "Server=.\\SQLEXPRESS;Database=ISTPET_DB;Trusted_Connection=True;TrustServerCertificate=True;";
        public bool IsApiOnline { get; private set; } = false;
        public bool IsSqlOnline { get; private set; } = false;
        public string ActiveModeDescription => IsApiOnline 
            ? $"🌐 API REST ({BaseUrl})" 
            : $"🗄️ SQL Server Directo (.\\SQLEXPRESS - ISTPET_DB)";

        public AlumnoApiClient(string baseUrl = "http://localhost:5292/api/alumnocontroller")
        {
            BaseUrl = NormalizeUrl(baseUrl);
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(4)
            };
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public void SetBaseUrl(string url)
        {
            BaseUrl = NormalizeUrl(url);
        }

        private string NormalizeUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                url = "http://localhost:5292/api/alumnocontroller";
            }
            return url.Trim().TrimEnd('/');
        }

        #region 1. GET - Obtener todos los alumnos

        public async Task<(bool Exito, List<Persona> Datos, string Mensaje)> ObtenerTodosAsync()
        {
            // Intentar primero por API REST
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    IsApiOnline = true;
                    var lista = JsonSerializer.Deserialize<List<Persona>>(content, _jsonOptions) ?? new List<Persona>();
                    return (true, lista, $"[API REST] Se cargaron {lista.Count} alumnos desde {BaseUrl}");
                }
            }
            catch
            {
                IsApiOnline = false;
            }

            // Si la API no responde, conectar directamente a SQL Server vía ADO.NET
            return await ObtenerTodosDesdeSqlAsync();
        }

        private async Task<(bool Exito, List<Persona> Datos, string Mensaje)> ObtenerTodosDesdeSqlAsync()
        {
            var lista = new List<Persona>();
            try
            {
                using var conn = new SqlConnection(SqlConnectionString);
                await conn.OpenAsync();
                IsSqlOnline = true;

                string query = "SELECT idpersonas, nombres, apellidos, cedula, activo FROM personas ORDER BY idpersonas DESC";
                using var cmd = new SqlCommand(query, conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
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

                return (true, lista, $"[SQL Server Directo] Se cargaron {lista.Count} alumnos desde ISTPET_DB.");
            }
            catch (Exception ex)
            {
                IsSqlOnline = false;
                return (false, lista, $"Error al conectar con SQL Server: {ex.Message}");
            }
        }

        #endregion

        #region 2. POST - Insertar alumno

        public async Task<(bool Exito, string Mensaje, Persona? Creado)> InsertarAsync(Persona persona)
        {
            // Intentar por API REST
            if (IsApiOnline)
            {
                try
                {
                    var json = JsonSerializer.Serialize(persona, _jsonOptions);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync(BaseUrl, content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, "[API REST] Alumno registrado exitosamente vía POST.", persona);
                    }
                }
                catch
                {
                    IsApiOnline = false;
                }
            }

            // Fallback a SQL Server Directo
            return await InsertarEnSqlAsync(persona);
        }

        private async Task<(bool Exito, string Mensaje, Persona? Creado)> InsertarEnSqlAsync(Persona persona)
        {
            try
            {
                using var conn = new SqlConnection(SqlConnectionString);
                await conn.OpenAsync();

                string query = "INSERT INTO personas (nombres, apellidos, cedula, activo) VALUES (@nombres, @apellidos, @cedula, @activo)";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombres", persona.Nombres ?? "");
                cmd.Parameters.AddWithValue("@apellidos", persona.Apellidos ?? "");
                cmd.Parameters.AddWithValue("@cedula", persona.Cedula ?? "");
                cmd.Parameters.AddWithValue("@activo", persona.Activo);

                await cmd.ExecuteNonQueryAsync();
                return (true, "[SQL Server] Alumno registrado exitosamente en la base de datos.", persona);
            }
            catch (Exception ex)
            {
                return (false, $"Error al insertar en SQL Server: {ex.Message}", null);
            }
        }

        #endregion

        #region 3. PUT - Actualizar alumno

        public async Task<(bool Exito, string Mensaje)> ActualizarAsync(Persona persona)
        {
            // Intentar por API REST
            if (IsApiOnline)
            {
                try
                {
                    var url = $"{BaseUrl}/{persona.Idpersonas}";
                    var json = JsonSerializer.Serialize(persona, _jsonOptions);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PutAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return (true, $"[API REST] Alumno #{persona.Idpersonas} actualizado vía PUT.");
                    }
                }
                catch
                {
                    IsApiOnline = false;
                }
            }

            // Fallback a SQL Server Directo
            return await ActualizarEnSqlAsync(persona);
        }

        private async Task<(bool Exito, string Mensaje)> ActualizarEnSqlAsync(Persona persona)
        {
            try
            {
                using var conn = new SqlConnection(SqlConnectionString);
                await conn.OpenAsync();

                string query = "UPDATE personas SET nombres = @nombres, apellidos = @apellidos, cedula = @cedula, activo = @activo WHERE idpersonas = @idpersonas";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idpersonas", persona.Idpersonas);
                cmd.Parameters.AddWithValue("@nombres", persona.Nombres ?? "");
                cmd.Parameters.AddWithValue("@apellidos", persona.Apellidos ?? "");
                cmd.Parameters.AddWithValue("@cedula", persona.Cedula ?? "");
                cmd.Parameters.AddWithValue("@activo", persona.Activo);

                await cmd.ExecuteNonQueryAsync();
                return (true, $"[SQL Server] Alumno #{persona.Idpersonas} actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar en SQL Server: {ex.Message}");
            }
        }

        #endregion

        #region 4. DELETE - Inactivar alumno (Borrado Lógico)

        public async Task<(bool Exito, string Mensaje)> EliminarAsync(int id)
        {
            // Intentar por API REST
            if (IsApiOnline)
            {
                try
                {
                    var url = $"{BaseUrl}/{id}";
                    var response = await _httpClient.DeleteAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        return (true, $"[API REST] Alumno #{id} inactivado vía DELETE.");
                    }
                }
                catch
                {
                    IsApiOnline = false;
                }
            }

            // Fallback a SQL Server Directo
            return await InactivarEnSqlAsync(id);
        }

        private async Task<(bool Exito, string Mensaje)> InactivarEnSqlAsync(int id)
        {
            try
            {
                using var conn = new SqlConnection(SqlConnectionString);
                await conn.OpenAsync();

                string query = "UPDATE personas SET activo = 0 WHERE idpersonas = @idpersonas";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idpersonas", id);

                await cmd.ExecuteNonQueryAsync();
                return (true, $"[SQL Server] Alumno #{id} cambiado a estado inactivo correctamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al inactivar en SQL Server: {ex.Message}");
            }
        }

        #endregion

        #region Diagnóstico de Conexión

        public async Task<(bool Conectado, string Mensaje, long LatenciaMs)> ProbarConexionAsync()
        {
            var sw = Stopwatch.StartNew();

            // 1. Probar API REST
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);
                sw.Stop();
                if (response.IsSuccessStatusCode)
                {
                    IsApiOnline = true;
                    return (true, $"API REST en línea (HTTP 200 - {sw.ElapsedMilliseconds} ms)", sw.ElapsedMilliseconds);
                }
            }
            catch
            {
                IsApiOnline = false;
            }

            // 2. Probar SQL Server Directo
            try
            {
                sw.Restart();
                using var conn = new SqlConnection(SqlConnectionString);
                await conn.OpenAsync();
                sw.Stop();
                IsSqlOnline = true;

                return (true, $"SQL Server en línea (.\\SQLEXPRESS / ISTPET_DB - {sw.ElapsedMilliseconds} ms)", sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                sw.Stop();
                IsSqlOnline = false;
                return (false, $"Sin conexión a SQL Server ni API: {ex.Message}", sw.ElapsedMilliseconds);
            }
        }

        #endregion
    }
}
