namespace API_Clinica.Modelo
{
    public class CitaMedica
    {
        public string Id { get; set; }
        public string Id_paciebte { get; set; }
        public string Id_medico { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Especialidad { get; set; }
        public string Estado { get; set; }

        public CitaMedica(string id, string id_paciebte, string id_medico, string fecha, 
            string hora, string especialidad)
        {
            Id = id;
            Id_paciebte = id_paciebte;
            Id_medico = id_medico;
            Fecha = fecha;
            Hora = hora;
            Especialidad = especialidad;
            Estado = "Pendiente"; //Pendiente por default
        }
    }
}
