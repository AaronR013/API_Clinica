using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace API_Clinica.Data
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;
        public DatabaseInitializer(IConfiguration configuration)
        {
            // Obtiene la cadena de conexión desde appsettings
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                Console.WriteLine("Inicializando base de datos...");

                // Lee el script SQL
                string scriptPath = Path.Combine(Directory.GetCurrentDirectory(),
                                               "Database", "SchemaApiClinica.sql");

                // SI no encuentra el script
                if (!File.Exists(scriptPath))
                {
                    Console.WriteLine("No se encontró el archivo SchemaApiClinica.sql");
                    return;
                }

                // Script cargado
                string fullScript = File.ReadAllText(scriptPath);
                Console.WriteLine($"Script SQL cargado");

                // Extrae el nombre de la BD de la cadena de conexión
                var builder = new MySqlConnectionStringBuilder(_connectionString);
                string databaseName = builder.Database; 
                builder.Database = ""; // Se conecta sin BD específica

                // Se conecta a MySQL Server (sin BD)
                using (var conn = new MySqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    Console.WriteLine("Conectado a MySQL Server");

                    // Ejecuta todo el script
                    using (var cmd = new MySqlCommand(fullScript, conn))
                    {
                        cmd.CommandTimeout = 300;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Script ejecutado con exito");
                            Console.WriteLine("Tablas y procedimientos creados");
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine($"Error MySQL: {ex.Message}");
                            Console.WriteLine($"Código: {ex.Number}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error crítico: {ex.Message}");
            }
        }
    }
}
