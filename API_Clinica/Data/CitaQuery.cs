using API_Clinica.Data;
using API_Clinica.Modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Clinica.Data
{
    public class CitaQuery
    {
        List<CitaMedica> citaMedicas;
        ConexionBD conexionBD;

        public CitaQuery()
        {
            citaMedicas = new List<CitaMedica>();
            conexionBD = new ConexionBD();
        }

        public List<CitaMedica> GetCitas()
        {
            List<CitaMedica> citaMedicas = new List<CitaMedica>();
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.obtenerTodosLasCitas", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                string id = lector["Id"].ToString();
                string id_paciente = lector["Id_paciente"].ToString();
                string id_medico = lector["Id_medico"].ToString();
                string fecha = lector["Fecha"].ToString();
                string hora = lector["Hora"].ToString();
                string especialidad = lector["Especialidad"].ToString();
                string estado = lector["Estado"].ToString();

                CitaMedica cita = new CitaMedica(id, id_paciente, id_medico, fecha, hora, especialidad, estado);
                citaMedicas.Add(cita);
            }

            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return citaMedicas;
        }

        public void AgregarCita(CitaMedica cita)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibclinica.insertCita", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("Id", cita.Id);
            comando.Parameters.AddWithValue("Id_paciebte", cita.Id_paciente);
            comando.Parameters.AddWithValue("Id_medico", cita.Id_medico);
            comando.Parameters.AddWithValue("Fecha", cita.Fecha);
            comando.Parameters.AddWithValue("Hora", cita.Hora);
            comando.Parameters.AddWithValue("Especialidad", cita.Especialidad);
            comando.Parameters.AddWithValue("Estado", "Pendiente"); //Pendiente por defecto

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public CitaMedica BuscarCita(string id)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.consultarCitaPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id", id);

            MySqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            CitaMedica cita = new CitaMedica(lector["Id"].ToString(), lector["Id_paciebte"].ToString(), 
                lector["Id_medico"].ToString(), lector["Fecha"].ToString(), lector["Hora"].ToString(), 
                lector["Especialidad"].ToString(), lector["Estado"].ToString());


            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return cita;
        }

        public void ActualizarCita(string id, CitaMedica cita)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.actualizarCitaPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("p_id", id);
            comando.Parameters.AddWithValue("Id_paciebte", cita.Id_paciente);
            comando.Parameters.AddWithValue("Id_medico", cita.Id_medico);
            comando.Parameters.AddWithValue("Fecha", cita.Fecha);
            comando.Parameters.AddWithValue("Hora", cita.Hora);
            comando.Parameters.AddWithValue("Especialidad", cita.Especialidad);
            comando.Parameters.AddWithValue("Estado", cita.Estado);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public void InactivarCita(string id)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.inactivarCitaPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id", id);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }
    }
}
