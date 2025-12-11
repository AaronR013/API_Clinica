namespace API_Clinica.Modelo
{
    public class CitaMedica
    {
        public string Id { get; set; }
        public string Id_paciente { get; set; }
        public string Id_medico { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Especialidad { get; set; }
        public string Estado { get; set; }

        public CitaMedica(string id, string id_paciente, string id_medico, string fecha, 
            string hora, string especialidad, string estado)
        {
            Id = id;
            Id_paciente = id_paciente;
            Id_medico = id_medico;
            Fecha = fecha;
            Hora = hora;
            Especialidad = especialidad;
            Estado = estado;
        }
    }
}
