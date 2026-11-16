# Laboratorio 06 – Programación modular y reutilización

**Proyecto:** LabTech – Sistema de control de préstamos de equipos  
**Curso:** Fundamentos de Programación  
**Universidad:** Universidad Privada del Norte (UPN)  
**Lenguaje:** C# (.NET 10)  
**Tema:** Introducción a la programación modular y reutilización

## Descripción

LabTech es una aplicación de consola para registrar equipos de un laboratorio universitario y gestionar sus préstamos y devoluciones. El proyecto se organiza en clases y métodos separados para facilitar la lectura, reutilización y mantenimiento del código.

## Funcionalidades

- Registrar equipos con código, nombre y categoría.
- Prestar un equipo a un estudiante, indicando la fecha.
- Devolver un equipo y actualizar su disponibilidad.
- Listar los equipos registrados y su estado.
- Consultar la cantidad de equipos disponibles por categoría.
- Validar códigos inexistentes o duplicados, datos vacíos y préstamos de equipos no disponibles.

## Estructura del proyecto

```text
laboratorio-06/
├── Program.cs
├── Equipo.cs
├── GestorPrestamos.cs
├── LabTech_Tema6.csproj
└── README.md
```

| Archivo | Responsabilidad |
|---|---|
| `Program.cs` | Ejecutar el menú principal y llamar a las operaciones del sistema. |
| `Equipo.cs` | Definir los datos de un equipo y su estado de préstamo. |
| `GestorPrestamos.cs` | Registrar, buscar, prestar, devolver y consultar equipos; validar entradas. |
| `LabTech_Tema6.csproj` | Configurar el proyecto de consola en .NET. |

## Cómo ejecutarlo

1. Tener instalado el **SDK de .NET 10**.
2. Abrir una terminal en la carpeta que contiene `LabTech_Tema6.csproj`.
3. Ejecutar:

```bash
dotnet run
```

### Menú del sistema

```text
1. Registrar equipo
2. Prestar equipo
3. Devolver equipo
4. Listar equipos
5. Consultar disponibilidad
6. Salir
```

## Pruebas funcionales

Durante las pruebas manuales se verificó lo siguiente:

| Caso | Resultado observado |
|---|---|
| Registro y préstamo del equipo `101` (Mouse) | Operaciones exitosas. |
| Devolución del equipo `101` | El equipo volvió a estar disponible. |
| Intento de prestar dos veces el equipo `101` | El segundo préstamo fue rechazado. |
| Búsqueda del código inexistente `998` para préstamo | El programa mostró un mensaje de error. |
| Registro con código vacío | El programa rechazó el dato. |
| Listado de equipos | Mostró los datos y el estado de disponibilidad. |
| Consulta de la categoría `periferico` | Mostró 1 equipo disponible en la prueba realizada. |

## Conceptos aplicados

- Programación modular mediante clases y métodos.
- Listas de objetos (`List<Equipo>`).
- Métodos con parámetros y valores de retorno.
- Reutilización de los métodos `BuscarEquipo()` y `ValidarTexto()`.
- Condicionales, ciclos y validación de entradas con `int.TryParse()`.
- Pruebas de casos válidos e inválidos.

## Consideraciones

- Los equipos se almacenan **en memoria**; al cerrar el programa se pierden los registros. No se implementó persistencia en archivos.
- La fecha del préstamo se solicita como texto en formato `dd/mm/aaaa`, pero el programa solo verifica que no esté vacía; no comprueba que sea una fecha válida.

---

Proyecto académico desarrollado para el Laboratorio del Tema 6 de Fundamentos de Programación.
