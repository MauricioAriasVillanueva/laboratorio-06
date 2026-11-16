
public class Equipo
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public bool Disponible { get; set; }
    public string Estudiante { get; set; }
    public string FechaPrestamo { get; set; }

    //INICIALIZAR DATOS DEL EQUIPO
    public Equipo(string codigo, string nombre, string categoria, bool disponible, string estudiante, string fechaPrestamo)
    {
        Codigo = codigo;
        Nombre = nombre;
        Categoria = categoria;
        Disponible = true;

        Estudiante = "";
        FechaPrestamo = "";
    }
}