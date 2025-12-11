namespace API_Clinica.Modelo
{
    public class HistorialMedico
    {
        public string Id { get; set; }
        public string Id_paciebte { get; set; }
        public string Id_medico { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Fecha_consulta { get; set; }

        public HistorialMedico(string id, string id_paciebte, string id_medico, string diagnostico, 
            string tratamiento, string fecha_consulta)
        {
            Id = id;
            Id_paciebte = id_paciebte;
            Id_medico = id_medico;
            Diagnostico = diagnostico;
            Tratamiento = tratamiento;
            Fecha_consulta = fecha_consulta;
        }
    }
}
