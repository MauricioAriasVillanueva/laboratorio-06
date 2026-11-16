
using System;

class Program
{
    static void Main()
    {
        GestorPrestamos gestor = new GestorPrestamos();
        int opcion;

        do
        {
            MostrarMenu();

            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = -1;
            }

            if (opcion == 1)
            {
                gestor.RegistrarEquipo();
            }
            else if (opcion == 2)
            {
                gestor.PrestarEquipo();
            }
            else if (opcion == 3)
            {
                gestor.DevolverEquipo();
            }
            else if (opcion == 4)
            {
                gestor.ListarEquipos();
            }
            else if (opcion == 5)
            {
                gestor.ConsultarDisponibilidad();
            }
            else if (opcion == 6)
            {
                Console.WriteLine("Saliendo del sistema...");
            }
            else
            {
                Console.WriteLine("Opcion no valida.");
            }

        } while (opcion != 6);

        Console.WriteLine("Programa finalizado.");
    }

    //MOSTRAR MENU PRINCIPAL
    static void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("           LABTECH - LABORATORIO");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Registrar equipo");
        Console.WriteLine("2. Prestar equipo");
        Console.WriteLine("3. Devolver equipo");
        Console.WriteLine("4. Listar equipos");
        Console.WriteLine("5. Consultar disponibilidad");
        Console.WriteLine("6. Salir");
        Console.WriteLine("========================================");
    }
}
