using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Programacion2
{
    class Program
    { 
            static void Main(string[] args)
            {
                Menu menu = new Menu();

                while (true)
                {
                    menu.MostrarMenu();

                    Console.Write("Selecciona una opción: ");
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            menu.AgregarEmpleado();
                            break;
                        case 2:
                            menu.ConsultarEmpleados();
                            break;
                        case 3:
                            menu.ModificarEmpleado();
                            break;
                        case 4:
                            menu.BorrarEmpleado();
                            break;
                        case 5:
                            menu.InicializarArreglos();
                            break;
                        case 6:
                            menu.MostrarReportes();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Introduce un número del 1 al 7.");
                            break;
                    }
                }
            }
        }

    }



