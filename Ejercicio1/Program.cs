using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, int> ips = new Dictionary<string, int>();

            ips.Add("1111.1111.1111.1111", 100);
            ips.Add("2222.2222.2222.2222", 200);
            ips.Add("3333.3333.3333.3333", 300);
            ips.Add("4444.4444.4444.4444", 400);
            ips.Add("5555.5555.5555.5555", 500);

                int opcion = 0;
                int seleccion = -1;
                string[] opciones = { "Introducir Datos", "Eliminar Dato", "Muestra Coleccion", "Mostrar Elemento", "Salir" };
                Console.CursorVisible = false;
                pintaMenu(opciones, opcion);
                do
                {
                    ConsoleKeyInfo tecla = Console.ReadKey();
                    switch (tecla.Key)
                    {
                        case ConsoleKey.DownArrow:
                            opcion = opcion < opciones.Length - 1 ? opcion + 1 : opcion;
                            break;
                        case ConsoleKey.UpArrow:
                            opcion = opcion > 0 ? opcion - 1 : opcion;
                            break;
                        case ConsoleKey.Spacebar:
                            seleccion = opcion;
                        switch (opcion)
                        {
                            case 0:
                                pedirDatos(ips[1]);

                                break;

                            default:
                                break;
                        }
                        break;
                        case ConsoleKey.Escape:
                            seleccion = opciones.Length - 1;
                            break;

                    }
                    pintaMenu(opciones, opcion);
                    Console.WriteLine("Opción elegida: {0}", seleccion);

                } while (seleccion != opciones.Length - 1); // Última opción Salir

            
        }
        static void pintaMenu(string[] opciones, int opcion)
        {
            string titulo = "MENU";

            Console.Clear();
            Console.WriteLine(titulo);
            for (int i = 0; i < opciones.Length; i++)
            {
                if (i == opcion) // Pinta la opción seleccionada en Video Inverso
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine(opciones[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

            }

        }

        static bool pedirDatos(DictionaryEntry dato)
        {

            bool isInt;

            int ram;
            int number;
            bool isValidNumber;
            string cadenaAComprobar = dato.Key.ToString();
            string[] partes = cadenaAComprobar.Split('.');

            isInt = int.TryParse(dato.Value.ToString(), out ram);

            if (!isInt)
            {
                Console.WriteLine("El valor introducido no es un entero");
                return false;
            }

            if (ram < 0)
            {
                Console.WriteLine("El valor de la ram no puede ser negativo");
                return false;
            }
            if (partes.Length != 4)
            {
                Console.WriteLine("La Ip no contiene los valores necesarios");
            }
            foreach (string parte in partes)
            {
                isValidNumber = int.TryParse(parte, out number);

                if (!isValidNumber)
                {
                    Console.WriteLine("Alguno de lo datos introducidos no es un entero");
                    return false;
                }

                if (number < 0 || number > 255)
                {
                    Console.WriteLine("Alguno de los datos introducidos no corresponde con los valores de una IPs");
                    return false;
                }
            }



            return true;
        }
    }
}
