using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1    //Preguntar a curro si ya esta validado.No tiene pinta
{
    internal static class Program// no informa al usuario. ---
                                 // Eliminar: pide dos veces la IP. ---
                                 // Bucle inf si no hay datos. --
                                 // Si ram no valida bucle inf. --
    {
        static void Main(string[] args)
        {
            Dictionary<String, int> ips = new Dictionary<string, int>();

            //ips.Add("255.255.255.0", 8);
            //ips.Add("255.2555.0.0", 8);
            //ips.Add("255.0.0.0", 16);
            //ips.Add("255.255.255.16", 16);

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
                string ip;
                string ram;
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

                               // pedirDatos(out ram, out ip);

                                //if (ips.ContainsKey(ip))
                                //{
                                //    Console.WriteLine(
                                //        "Ya se encuentra ese elemento en la lista de ips"
                                //    );
                                //}
                                //else
                                //{
                                //     .Add(ip, ram);
                                //}

                                Console.WriteLine("Se ha añadido correctamente e elemento");
                                Console.ReadKey();
                                break;
                            case 1:

                                if (ips.Count < 1)
                                {
                                    Console.WriteLine("No se han encontrado elementos en la coleccion");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    //ValidadorDeIp(out ip);
                                   // ips.Remove(ip);
                                    Console.WriteLine("Se ha eliminado correctamente el elemento");
                                }
                                break;

                            case 2:

                                if (ips.Count < 1)
                                {
                                    Console.WriteLine("No se han encontrado elementos en la coleccion");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    foreach (KeyValuePair<string, int> de in ips)
                                    {
                                        Console.WriteLine(
                                            $"La ip {de.Key} , tiene {de.Value} Gb de ram"
                                        );
                                    }
                                    Console.ReadKey();
                                }


                                break;
                            case 3:
                                if (ips.Count < 1)
                                {
                                    Console.WriteLine("No se han encontrado elementos en la coleccion");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    string ipAValidar;
                                    bool ipEncontrada;

                                    //do
                                    //{
                                    //   // ValidadorDeIp(out ipAValidar);

                                    //    if (!ips.ContainsKey(ipAValidar))
                                    //    {
                                    //        Console.WriteLine(
                                    //            "No se ha encontrado la ip deseada");
                                    //        Console.ReadKey();
                                    //        ipEncontrada = false;

                                    //    }
                                    //    else
                                    //    {
                                    //        ipEncontrada = true;
                                    //        Console.WriteLine(
                                    //        $"La ip {ipAValidar} , tiene {ips[ipAValidar]} Gb de ram");
                                    //        Console.ReadKey();

                                    //    }
                                    //} while (ipEncontrada);
                                }
                                break;
                            case 4:
                                Console.WriteLine("Hasta pronto!!");
                                Console.ReadKey();

                                break;

                            default:
                                Console.WriteLine("Opcion no valida");
                                Console.ReadKey();

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

        //public static void pedirDatos(out string ram, out string ip)
        //{
        //    bool isValidRam;
        //    bool isValidIp;

        //    do
        //    {
        //        Console.WriteLine("Por favor introduca el valor de la ip del dispositivo");
        //        ip = Console.ReadLine();
        //        isValidIp = ValidadorDeIp(ip);

        //    } while (!isValidIp);

        //    do
        //    {
        //        Console.WriteLine("Por favor introduca el valor de la ram del dispositivo");
        //        isValidRam = ValidadorDeIp(ram);

        //    } while (!isValidRam);
        //}

        //public static bool ValidadorDeRam(string out ram)
        //{
        //    bool isInt = int.TryParse(ram, out int ramN);

        //    if (!isInt)
        //    {
        //        return false;
        //    }

        //    if (ramN < 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        private static bool ValidadorDeIp(string ip)
        {
            bool isValidNumber;
            string[] partes = ip.Split('.');

            if (partes.Length != 4)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < partes.Length; i++)
                {
                    isValidNumber = int.TryParse(partes[i], out int number);

                    if (!isValidNumber)
                    {
                        return false;
                    }
                    if (number < 0 || number > 255)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
