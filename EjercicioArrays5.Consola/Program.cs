using System.Xml;
using Utilidades;
using ConsoleTables; 

namespace EjercicioArrays5.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Realizar un programa que permita generar una cantidad de 100 números al azar entre
            //1 y 10.Al finalizar la generación:
            //• Listar el resultado obtenido.
            //• Informar la frecuencia de cada número, esto es, la cantidad de veces que el
            //mismo aparece en el vector.
            int [] numerosGenerados = new int[100];
            bool seguir = true;
            do
            {   
                mostrarMenu();
                int opcionSeleccionada = IngresoDatos.PedirIntEnRango("Seleccione: ", 1, 5);
                switch (opcionSeleccionada)
                {
                    case 1:
                        GenerarNumerosAzar(numerosGenerados);
                        break;
                    case 2:
                        MostrarSuma(numerosGenerados);
                        break;
                    case 3:
                        MostrarNumerosGenerados(numerosGenerados);
                        break;
                    case 4:
                        MostrarFrecuencia(numerosGenerados);
                        break;
                    case 5:
                        seguir = false;
                        break;
                }
            } while (seguir);
            Console.WriteLine("Aplicacion finalizada");
        }

        private static void MostrarNumerosGenerados(int[] numerosGenerados)
        {
            var tabla = new ConsoleTable("Numeros generados");
            foreach (var numGenerado in numerosGenerados)
            {
                tabla.AddRow(numGenerado);
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizada("Listado realizado");
        }

        private static void MostrarFrecuencia(int[] numerosGenerados)
        {
            int[] frecuencia = new int[11];
            for (int i = 1; i < frecuencia.Length; i++)
            {
                frecuencia[i] = numerosGenerados.Count(n => n == i);
            }
            Console.Clear();
            for (int i = 1; i < frecuencia.Length; i++)
            {
                Console.WriteLine($"{i} - {frecuencia[i]}");
            }
            TareaFinalizada("Frecuencia de cada numero mostrada");
        }

        private static void MostrarSuma(int[] numerosGenerados)
        {
            Console.Clear();
            var suma = 0;
            foreach (var NumGenerado in numerosGenerados)
            {
                suma += NumGenerado;
            }
            Console.WriteLine($"La suma de los numeros generados es: {suma}");
            TareaFinalizada("Suma realizada");
        }

        private static void GenerarNumerosAzar(int[] numerosGenerados)
        {
            Console.Clear();
            Random r = new Random(Environment.TickCount);
            for (int i = 0; i < numerosGenerados.Length; i++)
            {
                numerosGenerados[i] = r.Next(1, 11);
            }
            TareaFinalizada("Numeros generados");
        }

        private static void TareaFinalizada(string mensaje)
        {
            Console.WriteLine($"{mensaje}... ENTER para continuar");
            Console.ReadLine();
        }

        private static void mostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("1-Generar numeros al azar");
            Console.WriteLine("2-Mostrar resultado de la suma de los numeros generados");
            Console.WriteLine("3-Mostrar numeros generados");
            Console.WriteLine("4-Mostrar la frecuencia de cada numero");
            Console.WriteLine("5-Salir");
        }
    }
}