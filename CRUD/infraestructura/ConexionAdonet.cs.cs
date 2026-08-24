


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
            string connectionString = _configuration.GetConnectionString("DefaultConnection") 
                ?? "Server=.\\SQLEXPRESS;Database=ISTPET_DB;Trusted_Connection=True;TrustServerCertificate=True;";
            return new SqlConnection(connectionString);
        }
    }
}


