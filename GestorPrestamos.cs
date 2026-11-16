using System;
using System.Collections.Generic;

class GestorPrestamos
{
    //ALMACENAR EQUIPOS
    private List<Equipo> equipos = new List<Equipo>();

    //BUSCAR EQUIPO POR CÓDIGO
    public Equipo? BuscarEquipo(string codigo)
    {
        foreach (Equipo equipo in equipos)
        {
            if (equipo.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
            {
                return equipo;
            }
        }
        return null;
    }

    //VALIDAR TEXTO
    private bool ValidarTexto(string texto)
    {
        return !string.IsNullOrWhiteSpace(texto);
    }

    //REGISTRAR EQUIPO
    public void RegistrarEquipo()
    {
        Console.WriteLine();
        Console.WriteLine("----REGISTRAR EQUIPO----");

        Console.Write("Ingrese el código del equipo: ");
        string codigo = (Console.ReadLine() ?? "").Trim();

        if (!ValidarTexto(codigo))
        {
            Console.WriteLine("Error: El código del equipo no puede estar vacío.");
            return;
        }

        if (BuscarEquipo(codigo) != null)
        {
            Console.WriteLine("Error: Ya existe un equipo con ese código.");
            return;
        }

        Console.Write("Ingrese el nombre del equipo: ");
        string nombre = (Console.ReadLine() ?? "").Trim();

        Console.Write("Ingrese la categoría del equipo: ");
        string categoria = (Console.ReadLine() ?? "").Trim();

        if (!ValidarTexto(nombre) || !ValidarTexto(categoria))
        {
            Console.WriteLine("Error: El nombre y la categoría del equipo no pueden estar vacíos.");
            return;
        }

        Equipo nuevoEquipo = new Equipo(codigo, nombre, categoria, true, "", "");
        equipos.Add(nuevoEquipo);

        Console.WriteLine("Equipo registrado exitosamente.");
    }

    public void PrestarEquipo()
    {
        Console.WriteLine();
        Console.WriteLine("----PRESTAR EQUIPO----");

        Console.Write("Ingrese el código del equipo a prestar: ");
        string codigo = (Console.ReadLine() ?? "").Trim();

        Equipo? equipo = BuscarEquipo(codigo);

        if (equipo == null)
        {
            Console.WriteLine("Error: No se encontró un equipo con ese código.");
            return;
        }

        if (!equipo.Disponible)
        {
            Console.WriteLine("Error: El equipo no está disponible para préstamo.");
            return;
        }

        Console.Write("Ingrese el nombre del estudiante: ");
        string estudiante = (Console.ReadLine() ?? "").Trim();

        Console.Write("Ingrese la fecha de préstamo (dd/mm/aaaa): ");
        string fecha = (Console.ReadLine() ?? "").Trim();

        if (!ValidarTexto(estudiante) || !ValidarTexto(fecha))
        {
            Console.WriteLine("Error: El nombre del estudiante no puede estar vacío.");
            return;
        }

        equipo.Disponible = false;
        equipo.Estudiante = estudiante;
        equipo.FechaPrestamo = fecha;

        Console.WriteLine("Equipo prestado exitosamente.");
    }

    //DEVOLVER EQUIPO
    public void DevolverEquipo()
    {
        Console.WriteLine();
        Console.WriteLine("----DEVOLVER EQUIPO----");

        Console.Write("Ingrese el código del equipo a devolver: ");
        string codigo = (Console.ReadLine() ?? "").Trim();

        Equipo? equipo = BuscarEquipo(codigo);

        if (equipo == null)
        {
            Console.WriteLine("Error: No se encontró un equipo con ese código.");
            return;
        }

        if (equipo.Disponible)
        {
            Console.WriteLine("Error: El equipo ya está disponible y no ha sido prestado.");
            return;
        }

        equipo.Disponible = true;
        equipo.Estudiante = "";
        equipo.FechaPrestamo = "";

        Console.WriteLine("Equipo devuelto exitosamente.");
    }

    //LISTAR EQUIPOS
    public void ListarEquipos()
    {
        Console.WriteLine();
        Console.WriteLine("----LISTA DE EQUIPOS----");

        if (equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
            return;
        }

        foreach (Equipo equipo in equipos)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Código: {equipo.Codigo}");
            Console.WriteLine($"Nombre: {equipo.Nombre}");
            Console.WriteLine($"Categoría: {equipo.Categoria}");

            if (equipo.Disponible)
            {
                Console.WriteLine("Estado: Disponible");
            }
            else
            {
                Console.WriteLine("Estado: Prestado");
                Console.WriteLine($"Estudiante: {equipo.Estudiante}");
                Console.WriteLine($"Fecha de Préstamo: {equipo.FechaPrestamo}");
            }
        }
    }

    //CONSULTAR DISPONIBILIDAD POR CATEGORÍA
    public void ConsultarDisponibilidad()
    {
        Console.WriteLine();
        Console.WriteLine("----CONSULTAR DISPONIBILIDAD POR CATEGORÍA----");

        Console.Write("Ingrese la categoría a consultar: ");
        string categoria = (Console.ReadLine() ?? "").Trim();

        if (!ValidarTexto(categoria))
        {
            Console.WriteLine("Error: La categoría no puede estar vacía.");
            return;
        }

        int cantidadDisponible = 0;

        foreach (Equipo equipo in equipos)
        {
            if (equipo.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase) && equipo.Disponible)
            {
                cantidadDisponible++;
            }
        }

        Console.WriteLine($"Cantidad de equipos disponibles en la categoría '{categoria}': {cantidadDisponible}");
    }
}