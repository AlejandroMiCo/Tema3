using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, int> ips = new Dictionary<string, int>();

            ips.Add("255.255.255.0", 8);
            ips.Add("255.2555.0.0", 8);
            ips.Add("255.0.0.0", 16);
            ips.Add("255.255.255.16", 16);

            int opcion = 0;
            int seleccion = -1;
            string[] opciones =
            {
                "Introducir Datos",
                "Eliminar Dato",
                "Muestra Coleccion",
                "Mostrar Elemento",
                "Salir",
            };
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
                        do
                        {
                            switch (opcion)
                            {
                                case 0:
                                    int ram;
                                    string ip;
                                    pedirDatos(out ram, out ip);
                                    ips.Add(ip, ram);

                                    break;
                                case 1:

                                    break;

                                case 2:

                                    break;

                                case 3:
                                    break;
                                case 4:
                                    Console.WriteLine("Hasta pronto!!");
                                    break;

                                default:
                                    break;
                            }
                        } while (opcion != 4);
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

        public static void pedirDatos(out int ram, out string ip)
        {
            bool isInt;
            int number;
            bool isValidNumber;
            bool isValidIp = true;
            bool isValidRam = true;

            do
            {
                Console.WriteLine("introduzca la ip del dispositivo:");
               ip = Console.ReadLine();
                string[] partes = ip.Split('.');

                if (partes.Length != 4)
                {
                    Console.WriteLine("La Ip no contiene los valores necesarios");
                    isValidIp = false;
                }
                else
                {
                    foreach (string parte in partes)
                    {
                        isValidNumber = int.TryParse(parte, out number);

                        if (!isValidNumber)
                        {
                            Console.WriteLine("Alguno de lo datos introducidos no es un entero");
                            isValidIp = false;
                        }
                        if (number < 0 || number > 255)
                        {
                            Console.WriteLine(
                                "Alguno de los datos introducidos no corresponde con los valores de una IPs"
                            );
                            isValidIp = false;
                        }
                    }
                }
            } while (!isValidIp);


            do
            {
                Console.WriteLine("introduzca la cantidad de ram del dispositivo:");
                isInt = int.TryParse(Console.ReadLine(), out ram);

                if (!isInt)
                {
                    Console.WriteLine("El valor introducido no es un entero");
                    isValidRam = false;
                }

                if (ram < 0)
                {
                    Console.WriteLine("El valor de la ram no puede ser negativo");
                    isValidRam = false;
                }
            } while (!isValidRam);
        }
    }
}
