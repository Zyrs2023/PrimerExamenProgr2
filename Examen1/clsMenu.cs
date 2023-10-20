using System;
using System.Linq;

class Menu
{
    private Empleado[] empleados;

    public Menu(int cantidadEmpleados)
    {
        empleados = new Empleado[cantidadEmpleados];
    }

    public void MostrarMenuPrincipal()
    {
        while (true)
        {
            Console.WriteLine("\nMenú Principal:");
            Console.WriteLine("1. Agregar Empleado");
            Console.WriteLine("2. Consultar Empleado");
            Console.WriteLine("3. Modificar Empleado");
            Console.WriteLine("4. Eliminar Empleado");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
            Console.WriteLine("Seleccione una opción:");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    ConsultarEmpleado();
                    break;
                case 3:
                    ModificarEmpleado();
                    break;
                case 4:
                    EliminarEmpleado();
                    break;
                case 5:
                    InicializarArreglos();
                    break;
                case 6:
                    MostrarMenuReportes();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    public void AgregarEmpleado()
    {
        Console.WriteLine("Ingrese la cédula del empleado:");
        string cedula = Console.ReadLine();
        Console.WriteLine("Ingrese el nombre del empleado:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la dirección del empleado:");
        string direccion = Console.ReadLine();
        Console.WriteLine("Ingrese el teléfono del empleado:");
        string telefono = Console.ReadLine();
        Console.WriteLine("Ingrese el salario del empleado:");
        double salario = double.Parse(Console.ReadLine());

        for (int i = 0; i < empleados.Length; i++)
        {
            if (empleados[i] == null)
            {
                empleados[i] = new Empleado(cedula, nombre, direccion, telefono, salario);
                Console.WriteLine("Empleado agregado correctamente.");
                return;
            }
        }
        Console.WriteLine("No hay espacio para agregar más empleados.");
    }

    public void ConsultarEmpleado()
    {
        Console.WriteLine("Ingrese la cédula del empleado:");
        string cedulaConsulta = Console.ReadLine();
        Empleado empleadoEncontrado = empleados.FirstOrDefault(e => e != null && e.Cedula == cedulaConsulta);

        if (empleadoEncontrado != null)
        {
            Console.WriteLine("Información del empleado:");
            Console.WriteLine($"Nombre: {empleadoEncontrado.Nombre}");
            Console.WriteLine($"Cédula: {empleadoEncontrado.Cedula}");
            Console.WriteLine($"Dirección: {empleadoEncontrado.Direccion}");
            Console.WriteLine($"Teléfono: {empleadoEncontrado.Telefono}");
            Console.WriteLine($"Salario: {empleadoEncontrado.Salario}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void ModificarEmpleado()
    {
        Console.WriteLine("Ingrese la cédula del empleado que desea modificar:");
        string cedulaModificar = Console.ReadLine();
        Empleado empleadoAModificar = empleados.FirstOrDefault(e => e != null && e.Cedula == cedulaModificar);

        if (empleadoAModificar != null)
        {
            Console.WriteLine("Ingrese el nuevo nombre del empleado:");
            string nuevoNombre = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva dirección del empleado:");
            string nuevaDireccion = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo teléfono del empleado:");
            string nuevoTelefono = Console.ReadLine();
            double nuevoSalario;

            if (double.TryParse(Console.ReadLine(), out nuevoSalario))
            {
                empleadoAModificar.Nombre = nuevoNombre;
                empleadoAModificar.Direccion = nuevaDireccion;
                empleadoAModificar.Telefono = nuevoTelefono;
                empleadoAModificar.Salario = nuevoSalario;
                Console.WriteLine("Empleado modificado correctamente.");
            }
            else
            {
                Console.WriteLine("Salario ingresado no válido. No se pudo modificar el empleado.");
            }
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void EliminarEmpleado()
    {
        Console.WriteLine("Ingrese la cédula del empleado a eliminar:");
        string cedulaEliminar = Console.ReadLine();
        for (int i = 0; i < empleados.Length; i++)
        {
            if (empleados[i] != null && empleados[i].Cedula == cedulaEliminar)
            {
                empleados[i] = null;
                Console.WriteLine("Empleado eliminado correctamente.");
                return;
            }
        }
        Console.WriteLine("Empleado no encontrado.");
    }

    public void InicializarArreglos()
    {
        empleados = new Empleado[empleados.Length];
        Console.WriteLine("Arreglos inicializados correctamente.");
    }

    public void MostrarMenuReportes()
    {
        while (true)
        {
            Console.WriteLine("\nMenú de Reportes:");
            Console.WriteLine("1. Consultar empleados con número de cédula.");
            Console.WriteLine("2. Listar todos los empleados ordenados por nombre.");
            Console.WriteLine("3. Calcular y mostrar el promedio de los salarios.");
            Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo.");
            Console.WriteLine("5. Volver al Menú Principal");
            Console.WriteLine("Seleccione una opción:");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese la cédula del empleado:");
                    string cedulaConsulta = Console.ReadLine();
                    Empleado empleadoConsulta = empleados.FirstOrDefault(e => e != null && e.Cedula == cedulaConsulta);

                    if (empleadoConsulta != null)
                    {
                        Console.WriteLine("Información del empleado:");
                        Console.WriteLine($"Nombre: {empleadoConsulta.Nombre}");
                        Console.WriteLine($"Cédula: {empleadoConsulta.Cedula}");
                        Console.WriteLine($"Dirección: {empleadoConsulta.Direccion}");
                        Console.WriteLine($"Teléfono: {empleadoConsulta.Telefono}");
                        Console.WriteLine($"Salario: {empleadoConsulta.Salario}");
                    }
                    else
                    {
                        Console.WriteLine("Empleado no encontrado.");
                    }
                    break;

                case 2:
                    ListarEmpleadosOrdenadosPorNombre();
                    break;

                case 3:
                    double promedioSalarios = CalcularPromedioSalarios();
                    Console.WriteLine($"Promedio de salarios: {promedioSalarios}");
                    break;

                case 4:
                    MostrarSalarioMaximoYMinimo();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    public void ListarEmpleadosOrdenadosPorNombre()
    {
        var empleadosOrdenados = empleados.Where(e => e != null).OrderBy(e => e.Nombre);

        foreach (var empleado in empleadosOrdenados)
        {
            Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}");
        }
    }

    public double CalcularPromedioSalarios()
    {
        double totalSalarios = 0;
        int contador = 0;

        foreach (var empleado in empleados)
        {
            if (empleado != null)
            {
                totalSalarios += empleado.Salario;
                contador++;
            }
        }

        if (contador > 0)
        {
            return totalSalarios / contador;
        }
        else
        {
            return 0;
        }
    }

    public void MostrarSalarioMaximoYMinimo()
    {
        double salarioMaximo = double.MinValue;
        double salarioMinimo = double.MaxValue;

        foreach (var empleado in empleados)
        {
            if (empleado != null)
            {
                if (empleado.Salario > salarioMaximo)
                {
                    salarioMaximo = empleado.Salario;
                }

                if (empleado.Salario < salarioMinimo)
                {
                    salarioMinimo = empleado.Salario;
                }
            }
        }

        Console.WriteLine($"Salario máximo: {salarioMaximo}");
        Console.WriteLine($"Salario mínimo: {salarioMinimo}");
    }
}