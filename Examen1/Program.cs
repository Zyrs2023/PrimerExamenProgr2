using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la cantidad máxima de empleados:");
        int cantidadEmpleados = int.Parse(Console.ReadLine());

        Menu menu = new Menu(cantidadEmpleados);
        menu.MostrarMenuPrincipal();
    }
}