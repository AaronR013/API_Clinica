using API_Clinica.Data;
using API_Clinica.Modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Clinica.Data
{
    public class PacienteQuery
    {
        List<Paciente> pacientes;
        ConexionBD conexionBD;

        public PacienteQuery()
        {
            pacientes = new List<Paciente>();
            conexionBD = new ConexionBD();
        }

        public List<Paciente> GetPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.obtenerTodosLosPacientes", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                string id = lector["Id"].ToString();
                string nombre = lector["Nombre"].ToString();
                string cedula = lector["Cedula"].ToString();
                string fecha_nacimiento = lector["Fecha_nacimiento"].ToString();
                string genero = lector["Genero"].ToString();
                string direccion = lector["Direccion"].ToString();
                string telefono = lector["Telefono"].ToString();
                string correo = lector["Correo"].ToString();
                string estado_clinico = lector["Estado_clinico"].ToString();
                string fecha_registro = lector["Fecha_registro"].ToString();

                Paciente paciente = new Paciente(id, nombre, cedula, fecha_nacimiento, genero, 
                    direccion, telefono, correo, estado_clinico, fecha_registro);
                pacientes.Add(paciente);
            }

            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return pacientes;
        }

        public void AgregarPaciente(Paciente paciente)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apibclinica.insertPaciente", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("Id", paciente.Id);
            comando.Parameters.AddWithValue("Nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("Cedula", paciente.Cedula);
            comando.Parameters.AddWithValue("Fecha_nacimiento", paciente.Fecha_nacimiento);
            comando.Parameters.AddWithValue("Genero", paciente.Genero);
            comando.Parameters.AddWithValue("Direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("Telefono", paciente.Telefono);
            comando.Parameters.AddWithValue("Correo", paciente.Correo);
            comando.Parameters.AddWithValue("Estado_clinico", "Activo"); //Activo por defecto
            comando.Parameters.AddWithValue("Fecha_registro", paciente.Fecha_registro);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public Paciente BuscarPaciente(string cedula)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.consultarPacientePorCedula", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_cedula", cedula);

            MySqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            Paciente paciente = new Paciente(lector["Id"].ToString(), lector["Nombre"].ToString(), lector["Cedula"].ToString(), 
                lector["Fecha_nacimiento"].ToString(), lector["Genero"].ToString(), lector["Direccion"].ToString(), 
                lector["Telefono"].ToString(), lector["Correo"].ToString(), lector["Estado_clinico"].ToString(), 
                lector["Fecha_registro"].ToString());


            lector.Close();
            conexionBD.CerrarConexion(conexion);
            return paciente;
        }

        public void ActualizarPaciente(string id, Paciente paciente)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.actualizarPacientePorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("p_id", id);
            comando.Parameters.AddWithValue("Nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("Cedula", paciente.Cedula);
            comando.Parameters.AddWithValue("Fecha_nacimiento", paciente.Fecha_nacimiento);
            comando.Parameters.AddWithValue("Genero", paciente.Genero);
            comando.Parameters.AddWithValue("Direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("Telefono", paciente.Telefono);
            comando.Parameters.AddWithValue("Correo", paciente.Correo);
            comando.Parameters.AddWithValue("Estado_clinico", paciente.Estado_clinico);
            comando.Parameters.AddWithValue("Fecha_registro", paciente.Fecha_registro);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }

        public void InactivarPaciente(string id)
        {
            MySqlConnection conexion = conexionBD.AbrirConexion();

            MySqlCommand comando = new MySqlCommand("apiclinica.inactivarPacientePorId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_id", id);

            comando.ExecuteNonQuery();
            conexionBD.CerrarConexion(conexion);
        }
    }
}
