namespace API_Clinica.Modelo
{
    public class HistorialMedico
    {
        public string Id { get; set; }
        public string Id_paciente { get; set; }
        public string Id_medico { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Fecha_consulta { get; set; }

        public HistorialMedico(string id, string id_paciente, string id_medico, string diagnostico, 
            string tratamiento, string fecha_consulta)
        {
            Id = id;
            Id_paciente = id_paciente;
            Id_medico = id_medico;
            Diagnostico = diagnostico;
            Tratamiento = tratamiento;
            Fecha_consulta = fecha_consulta;
        }
    }
}
