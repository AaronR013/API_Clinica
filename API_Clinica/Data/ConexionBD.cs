using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Clinica.Data
{
    public class ConexionBD
    {
        private readonly string _cadenaConexion;

        public ConexionBD()
        {
            // Carga la configuración desde appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Obtiene la cadena de conexión
            _cadenaConexion = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(_cadenaConexion))
            {
                // Valor por defecto si no se encuentra
                _cadenaConexion = "Server=localhost;Port=3306;Database=apiclinica;User Id=root;Password=;";
                Console.WriteLine("Usando cadena de conexión por defecto");
            }
        }

        public MySqlConnection AbrirConexion()
        {

            MySqlConnection conexion = new MySqlConnection(_cadenaConexion);
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión MySQL abierta correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión MySQL: " + ex.Message);
                Console.WriteLine($"   Cadena usada: {_cadenaConexion}");
                throw; // Relanzar para manejo superior
            }
            return conexion;
        }

        public void CerrarConexion(MySqlConnection conexion)
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                Console.WriteLine("Conexión MySQL cerrada.");
            }
        }
    }
}
