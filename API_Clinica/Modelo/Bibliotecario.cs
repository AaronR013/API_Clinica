namespace API_Clinica.Modelo
{
    public class Bibliotecario
    {
        public string Id_empleado { get; set; }

        public int Años_experiencia { get; set; }

        public Bibliotecario(string id_empleado, int años_experiencia) 
        {
            Id_empleado = id_empleado;

            Años_experiencia = años_experiencia;
        }
    }
}
