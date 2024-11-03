using MySql.Data.MySqlClient;


namespace Backend.Services
{
    public class ConexionServices
    {
        private MySqlConnection conex = new MySqlConnection();


        private string cadenaConexion;

        public ConexionServices(IConfiguration configuration)
        {
            // Obtiene la cadena de conexión desde appsettings.json
            cadenaConexion = configuration.GetConnectionString("MyDB")!;
        }


        public MySqlConnection EstablecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                Console.WriteLine("Conexión establecida correctamente a la base de datos.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"No se pudo conectar a la base de datos: {e.Message}");
                return null;
            }
            return conex;
        }

        public void CerrarConexion()
        {
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
                Console.WriteLine("Conexión cerrada correctamente.");
            }
        }
    }
}
