namespace API_Clinica.Modelo
{
    public class Paciente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Fecha_nacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estado_clinico { get; set; }
        public string Fecha_registro { get; set; }

        public Paciente(string id, string nombre, string cedula, string fecha_nacimiento, 
            string genero, string direccion, string telefono, string correo, string estado_clinico, string fecha_registro)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;
            Fecha_nacimiento = fecha_nacimiento;
            Genero = genero;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            Estado_clinico = estado_clinico;
            Fecha_registro = fecha_registro;
        }
    }
}
