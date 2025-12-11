using API_Clinica.Data;
using API_Clinica.Modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Clinica.Data
{
    public class LibroQuery
    {
        List<Libro> libros;
        ConexionBD conexionBD;

        public LibroQuery()
        {
            libros = new List<Libro>();
            conexionBD = new ConexionBD();
        }

        public List<Libro> GetLibros()
        {
            List<Libro> libros = new List<Libro>();
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.obtenerTodosLosLibros", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                string id_libro = lector["Id_libro"].ToString();
                string titulo = lector["Titulo"].ToString();
                string autor = lector["Autor"].ToString();

                Libro libro = new Libro(id_libro, titulo, autor);
                libros.Add(libro);
            }

            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return libros;
        }


        public void AgregarLibro(Libro libro)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.insertLibro", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("Id_libro", libro.Id_libro);
            comando.Parameters.AddWithValue("Titulo", libro.Titulo);
            comando.Parameters.AddWithValue("Autor", libro.Autor);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public Libro BuscarLibro(string id_libro)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.consultarLibroPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id_libro", id_libro);

            MySqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            Libro libro = new Libro(lector["Id_libro"].ToString(), lector["Titulo"].ToString(), lector["Autor"].ToString());


            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return libro;
        }

        public void ActualizarLibro(string id_libro, Libro libro)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.actualizarLibroPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("p_id_libro", id_libro);
            comando.Parameters.AddWithValue("Titulo", libro.Titulo);
            comando.Parameters.AddWithValue("Autor", libro.Autor);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public void InactivarLibro(string id_libro)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibiblioteca.eliminarLibroPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id_libro", id_libro);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }
    }
}
