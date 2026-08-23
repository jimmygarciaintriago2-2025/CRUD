


using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace CRUD.infraestructura
{
    public class ConexionAdonet 
    {
        private readonly IConfiguration _configuration;

        public ConexionAdonet(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection ObtenerConexion()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }
    }
}


