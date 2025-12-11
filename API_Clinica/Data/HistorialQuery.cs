using API_Clinica.Data;
using API_Clinica.Modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Clinica.Data
{
    public class HistorialQuery
    {
        List<HistorialMedico> historialMedicos;
        ConexionBD conexionBD;

        public HistorialQuery()
        {
            historialMedicos = new List<HistorialMedico>();
            conexionBD = new ConexionBD();
        }

        public List<HistorialMedico> GetHistoriales()
        {
            List<HistorialMedico> historialMedicos = new List<HistorialMedico>();
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.obtenerTodosLosHistoriales", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                string id = lector["Id"].ToString();
                string id_paciente = lector["Id_paciente"].ToString();
                string id_medico = lector["Id_medico"].ToString();
                string diagnostico = lector["Diagnostico"].ToString();
                string tratamiento = lector["Tratamiento"].ToString();
                string fecha_consulta = lector["Fecha_consulta"].ToString();

                HistorialMedico historial = new HistorialMedico(id, id_paciente, id_medico, diagnostico, tratamiento, fecha_consulta);
                historialMedicos.Add(historial);
            }

            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return historialMedicos;
        }

        public void AgregarHistorial(HistorialMedico historial)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.insertHistorial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("Id", historial.Id);
            comando.Parameters.AddWithValue("Id_paciente", historial.Id_paciente);
            comando.Parameters.AddWithValue("Id_medico", historial.Id_medico);
            comando.Parameters.AddWithValue("Diagnostico", historial.Diagnostico);
            comando.Parameters.AddWithValue("Tratamiento", historial.Tratamiento);
            comando.Parameters.AddWithValue("Fecha_consulta", historial.Fecha_consulta);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public HistorialMedico BuscarHistorial(string id)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.consultarHistorialPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id", id);

            MySqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            HistorialMedico historial = new HistorialMedico(lector["Id"].ToString(), lector["Id_paciente"].ToString(),
                lector["Id_medico"].ToString(), lector["Diagnostico"].ToString(), lector["Tratamiento"].ToString(),
                lector["Fecha_consulta"].ToString());


            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return historial;
        }

        public void ActualizarCita(string id, HistorialMedico historial)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.actualizarHistorialPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("p_id", id);
            comando.Parameters.AddWithValue("Id_paciente", historial.Id_paciente);
            comando.Parameters.AddWithValue("Id_medico", historial.Id_medico);
            comando.Parameters.AddWithValue("Diagnostico", historial.Diagnostico);
            comando.Parameters.AddWithValue("Tratamiento", historial.Tratamiento);
            comando.Parameters.AddWithValue("Fecha_consulta", historial.Fecha_consulta);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }
    }
}
