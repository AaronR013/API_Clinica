using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Clinica.Data
{
    public class ConexionBD
    {
        private const string cadenaConexion = "Server=localhost;Port=3306;Database=apibiblioteca;User Id=root;Password=Bdrt5301*;";



        public ConexionBD()
        { 
           
        }

        public MySqlConnection AbrirConexion()
        {

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión MySQL abierta correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión MySQL: " + ex.Message);
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
