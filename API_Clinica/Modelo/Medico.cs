namespace API_Clinica.Modelo
{
    public class Medico
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula_profesional { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Horario_consulta { get; set; }
        public string Estado { get; set; }

        public Medico(string id, string nombre, string cedula_profesional, string especialidad, 
            string telefono, string correo, string horario_consulta, string estado)
        {
            Id = id;
            Nombre = nombre;
            Cedula_profesional = cedula_profesional;
            Especialidad = especialidad;
            Telefono = telefono;
            Correo = correo;
            Horario_consulta = horario_consulta;
            Estado = estado;
        }
    }
}
