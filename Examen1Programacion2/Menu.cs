using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Programacion2
{


public class Menu
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void MostrarMenu()
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
        }

        public void AgregarEmpleado()
        {
            Console.Write("Ingresa la cédula: ");
            string cedula = Console.ReadLine();
            if (BuscarEmpleadoPorCedula(cedula) != null)
            {
                Console.WriteLine("Ya existe un empleado con esa cédula.");
                return;
            }
            Console.Write("Ingresa el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingresa la dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingresa el teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingresa el salario: ");
            double salario = Convert.ToDouble(Console.ReadLine());

            Empleado empleado = new Empleado(cedula, nombre, direccion, telefono, salario);
            empleados.Add(empleado);
            Console.WriteLine("Empleado agregado con éxito.");
        }

        public void ConsultarEmpleados()
        {
            Console.Write("Ingresa la cédula del empleado a consultar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = BuscarEmpleadoPorCedula(cedula);

            if (empleado != null)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void ModificarEmpleado()
        {
            Console.Write("Ingresa la cédula del empleado a modificar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = BuscarEmpleadoPorCedula(cedula);

            if (empleado != null)
            {
                Console.Write("Nuevo nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Nueva dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Nuevo teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Nuevo salario: ");
                empleado.Salario = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Empleado modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void BorrarEmpleado()
        {
            Console.Write("Ingresa la cédula del empleado a borrar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = BuscarEmpleadoPorCedula(cedula);

            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("Empleado eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void InicializarArreglos()
        {
            empleados.Clear();
            Console.WriteLine("Arreglos inicializados.");
        }

        public void MostrarReportes()
        {
            while (true)
            {
                Console.WriteLine("Menú de Reportes");
                Console.WriteLine("1. Consultar empleados con número de cédula.");
                Console.WriteLine("2. Listar todos los empleados ordenados por nombre.");
                Console.WriteLine("3. Calcular y mostrar el promedio de los salarios.");
                Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo.");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Selecciona una opción: ");
                int opcionReporte = int.Parse(Console.ReadLine());

                switch (opcionReporte)
                {
                    case 1:
                        Console.Write("Ingresa la cédula del empleado a consultar: ");
                        string cedula = Console.ReadLine();
                        ConsultarEmpleadosPorCedula(cedula);
                        break;
                    case 2:
                        ListarEmpleadosOrdenadosPorNombre();
                        break;
                    case 3:
                        CalcularPromedioSalarios();
                        break;
                    case 4:
                        CalcularSalarioMasAltoYMasBajo();
                        break;
                    case 5:
                        return; 
                    default:
                        Console.WriteLine("Opción no válida. Introduce un número del 1 al 5.");
                        break;
                }
            }
        }

        public void ConsultarEmpleadosPorCedula(string cedula)
        {
            Empleado empleado = BuscarEmpleadoPorCedula(cedula);

            if (empleado != null)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void ListarEmpleadosOrdenadosPorNombre()
        {
            var empleadosOrdenados = empleados.OrderBy(e => e.Nombre);

            Console.WriteLine("Empleados ordenados por nombre:");
            foreach (var empleado in empleadosOrdenados)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}");
            }
        }

        public void CalcularPromedioSalarios()
        {
            if (empleados.Count > 0)
            {
                double sumaSalarios = empleados.Sum(e => e.Salario);
                double promedioSalarios = sumaSalarios / empleados.Count;
                Console.WriteLine($"El promedio de los salarios es: {promedioSalarios}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el promedio de salarios.");
            }
        }

        public void CalcularSalarioMasAltoYMasBajo()
        {
            if (empleados.Count > 0)
            {
                double salarioMasAlto = empleados.Max(e => e.Salario);
                double salarioMasBajo = empleados.Min(e => e.Salario);

                Console.WriteLine($"Salario más alto: {salarioMasAlto}");
                Console.WriteLine($"Salario más bajo: {salarioMasBajo}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el salario más alto y el más bajo.");
            }
        }
        private Empleado BuscarEmpleadoPorCedula(string cedula)
        {
            return empleados.FirstOrDefault(e => e.Cedula == cedula);
        }
    }

}

