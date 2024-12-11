using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Menu
    {
        Aula aula = new Aula(new string[] { "Alex", "javi", "Cris", "Adri" });
        int opc;
        Asignaturas asig;

        public Menu(params string[] nombres) { }

        public void Inicio()
        {
            aula.RellenaNotas();

            do
            {
                Console.Clear();
                Console.WriteLine("Opcion 1. Calcular la media de notas de toda la tabla.");
                Console.WriteLine("Opcion 2. Media de un alumno");
                Console.WriteLine("Opcion 3. Media de una asignatura");
                Console.WriteLine("Opcion 4. Visualizar notas de un alumno");
                Console.WriteLine("Opcion 5. Visualizar asignaturas");
                Console.WriteLine("Opcion 6. Nota maxima y minima de un alumno");
                Console.WriteLine("Opcion 7. Visualizar tabla completa");
                Console.WriteLine("Opcion 8. Salir");

                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Error, el valor introducido no es un numero entero");
                }
                else
                {
                    switch (opc - 1)
                    {
                        case 0: //Calcular la media de notas de toda la tabla.
                            Console.WriteLine($"La media de las notas de toda la tabla es: {aula.CalcularMediasGlobales()}");
                            Console.ReadKey();
                            break;
                        case 1: //Media de un alumno


                            Console.WriteLine(aula.CalcularMediasAlumno(SelecionAlumno()));

                            Console.ReadKey();

                            break;
                        case 2: //Media de una asignatura
                            aula.MediaDeUnaAsignatura(0);

                            Console.ReadKey();

                            break;
                        case 3: //Visualizar notas de un alumno
                            VisualizarNotasAlumno(0);

                            Console.ReadKey();
                            break;
                        case 4: //Visualizar asignaturas
                            VisualizarNotasAlumno(0);

                            Console.ReadKey();

                            break;
                        case 5: //Nota maxima y minima de un alumno
                            aula.NotasMaxAndMin(0, out int max, out int min);

                            Console.ReadKey();

                            break;
                        case 6: //Visualizar tabla completa
                            MostrarTabla();

                            Console.ReadKey();

                            break;
                        case 7:
                            Console.WriteLine("Hasta pronto!");

                            Console.ReadKey();

                            break;
                        default:
                            Console.WriteLine("Error, intentelo de nuevo por favor");
                            break;
                    }
                }
            } while (opc != 8);
        }

        private void VisualizarNotasAlumno(int alumno)
        {
            int[] notasAlumno = new int[aula.notas.GetLength(1)];

            for (int i = 0; i < aula.notas.GetLength(1); i++)
            {
                notasAlumno[i] = aula.notas[alumno, i];
            }

            Console.WriteLine(
                $"%3{notasAlumno[0]} %3{notasAlumno[1]} %3{notasAlumno[2]} %3{notasAlumno[3]}"
            );
        }

        private void VisualizarNotasAsignatura(int asignatura)
        {
            int[] notasAsignauras = new int[aula.notas.GetLength(0)];

            for (int i = 0; i < aula.notas.GetLength(0); i++)
            {
                notasAsignauras[i] = aula.notas[i, asignatura];
            }

            Console.WriteLine(
                $"%3{notasAsignauras[0]} %3{notasAsignauras[1]} %3{notasAsignauras[2]} %3{notasAsignauras[3]}"
            );
        }

        private void MostrarTabla()
        {
            Console.WriteLine($"{(Asignaturas)0,25}{(Asignaturas)1,15}{(Asignaturas)2,15}{(Asignaturas)3,15}");
            for (int i = 0; i < aula.notas.GetLength(0); i++)
            {
                Console.Write($"{aula[i],-10}");
                for (int j = 0; j < aula.notas.GetLength(1); j++)
                {
                    Console.Write($"{aula.notas[i, j],15}");
                }
                Console.WriteLine();
            }
        }

        private int SelecionAlumno()
        {
            bool error = true;
            do
            {
                Console.WriteLine("Por favor, selecione el alumno por su numero");
                for (int i = 0; i < aula.notas.GetLength(0); i++)
                {
                    Console.WriteLine($"{i + 1}. {aula[i]}");
                }
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Error, no se ha podido reconocer un numero valido");
                }
                else
                {
                    if (opc > 0 && opc <= aula.notas.GetLength(0))
                    {
                        error = false;
                    }
                    else
                    {
                        Console.WriteLine("El numero no se enuentra dentro de los valores de la tabla");
                    }
                }
            }
            while (error);

            return opc+1;
        }


        private int SelecionAsignatura()
        {
            bool error = true;
            do
            {
                Console.WriteLine("Por favor, selecione la asignatura por su numero");
                for (int i = 0; i < Enum.GetValues(typeof(Asignaturas)).Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {aula[i]}");
                }
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Error, no se ha podido reconocer un numero valido");
                }
                else
                {
                    if (opc >= 0 && opc < aula.notas.GetLength(1))
                    {
                        error = false;
                    }
                    else
                    {
                        Console.WriteLine("El numero no se enuentra dentro de los valores de la tabla");
                    }
                }
            }
            while (error);

            return opc+1;
        }
    }
}
