using API_Clinica.Data;
using API_Clinica.Modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Clinica.Data
{
    public class MedicoQuery
    {
        List<Medico> medicos;
        ConexionBD conexionBD;

        public MedicoQuery()
        {
            medicos = new List<Medico>();
            conexionBD = new ConexionBD();
        }

        public List<Medico> GetMedicos()
        {
            List<Medico> medicos = new List<Medico>();
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.obtenerTodosLosMedicos", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                string id = lector["Id"].ToString();
                string nombre = lector["Nombre"].ToString();
                string cedula_profesional = lector["Cedula_profesional"].ToString();
                string especialidad = lector["Especialidad"].ToString();
                string telefono = lector["Telefono"].ToString();
                string correo = lector["Correo"].ToString();
                string horario_consulta = lector["Horario_consulta"].ToString();
                string estado = lector["Estado"].ToString();

                Medico medico = new Medico(id, nombre, cedula_profesional, especialidad, 
                    telefono, correo, horario_consulta, estado);
                medicos.Add(medico);
            }

            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return medicos;
        }

        public void AgregarMedico(Medico medico)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibclinica.insertMedico", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("Id", medico.Id);
            comando.Parameters.AddWithValue("Nombre", medico.Nombre);
            comando.Parameters.AddWithValue("Cedula_profesional", medico.Cedula_profesional);
            comando.Parameters.AddWithValue("Especialidad", medico.Especialidad);
            comando.Parameters.AddWithValue("Telefono", medico.Telefono);
            comando.Parameters.AddWithValue("Correo", medico.Correo);
            comando.Parameters.AddWithValue("Horario_consulta", medico.Horario_consulta);
            comando.Parameters.AddWithValue("Estado", "Activo"); //Activo por defecto

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public Medico BuscarMedico(string id)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.consultarMedicoPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id", id);

            MySqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            Medico medico = new Medico(lector["Id"].ToString(), lector["Nombre"].ToString(), lector["Cedula_profesional"].ToString(),
                lector["Especialidad"].ToString(), lector["Telefono"].ToString(), lector["Correo"].ToString(), 
                lector["Horario_consulta"].ToString(),lector["Estado"].ToString());


            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return medico;
        }

        public void ActualizarMedico(string id, Medico medico)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.actualizarMedicoPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("p_id", id);
            comando.Parameters.AddWithValue("Nombre", medico.Nombre);
            comando.Parameters.AddWithValue("Cedula_profesional", medico.Cedula_profesional);
            comando.Parameters.AddWithValue("Especialidad", medico.Especialidad);
            comando.Parameters.AddWithValue("Telefono", medico.Telefono);
            comando.Parameters.AddWithValue("Correo", medico.Correo);
            comando.Parameters.AddWithValue("Horario_consulta", medico.Horario_consulta);
            comando.Parameters.AddWithValue("Estado", medico.Estado);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public void InactivarMedico(string id)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.inactivarMedicoPorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id", id);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }
    }
}
