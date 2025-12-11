using API_Clinica.Data;
using API_Clinica.Modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Clinica.Data
{
    public class BibliotecarioQuery
    {
        List<Bibliotecario> bibliotecarios;
        ConexionBD conexionBD;

        public BibliotecarioQuery()
        {
            bibliotecarios = new List<Bibliotecario>();
            conexionBD = new ConexionBD();
        }

        public List<Bibliotecario> GetBibliotecarios()
        {
            List<Bibliotecario> bibliotecarios = new List<Bibliotecario>();
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.obtenerTodosLosBibliotecarios", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                string id_empleado = lector["Id_empleado"].ToString();
                int años_experiencia = Convert.ToInt32(lector["Años_experiencia"]);

                Bibliotecario bibliotecario = new Bibliotecario(id_empleado, años_experiencia);
                bibliotecarios.Add(bibliotecario);
            }

            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return bibliotecarios;
        }


        public void AgregarBibliotecario(Bibliotecario bibliotecario)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.insertBibliotecario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("Id_empleado", bibliotecario.Id_empleado);
            comando.Parameters.AddWithValue("Años_experiencia", bibliotecario.Años_experiencia);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public Bibliotecario BuscarBibliotecario(string id_empleado)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.consultarBibliotecarioPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id_empleado", id_empleado);

            MySqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            Bibliotecario bibliotecario = new Bibliotecario(lector["Id_empleado"].ToString(), Convert.ToInt32(lector["Años_experiencia"]));


            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return bibliotecario;
        }

        public void ActualizarBibliotecario(string id_empleado, Bibliotecario bibliotecario)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.actualizarBibliotecarioPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("p_id_empleado", id_empleado);
            comando.Parameters.AddWithValue("Años_experiencia", bibliotecario.Años_experiencia);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public void InactivarBibliotecario(string id_empleado)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.eliminarBibliotecarioPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id_empleado", id_empleado);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }
    }
}


