namespace API_Clinica.Modelo
{
    public class Libro
    {
        public string Id_libro { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public Libro(string id_libro, string titulo, string autor)
        {
            Id_libro = id_libro;

            Titulo = titulo;

            Autor = autor;
        }
    }
}
