using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Aula
{
    public int[,] notas;
    String[] alumnos;

    public Aula(String[] nombres)
    {
        for (int i = 0; i < nombres.Length; i++)
        {
            this.alumnos[i] = nombres[i].Trim().ToUpper();
        }
        notas = new int[nombres.Length, 4];
    }

    public Aula(string nombres)
    {
        string[] aux = nombres.Split(',');
        for (int i = 0; i < aux.Length; i++)
        {
            this.alumnos[i] = aux[i].Trim().ToUpper();
        }
    }

    public int CalcularMediasGlobales(int[,] notas)
    {
        int acu = 0;

        foreach (var nota in notas)
        {
            acu += nota;
        }

        return acu / notas.Length;
    }

    public int CalcularMediasAlumno(int[,] notas, int alumno)
    {
        int acu = 0;
        for (int j = 0; j < notas.GetLength(1); j++)
        {
            acu += notas[alumno, j];
        }

        return acu / notas.GetLength(1);
    }

    public int MediaDeUnaAsignatura(int[,] notas, int asignatura)
    {
        int acu = 0;

        for (int i = 0; i < notas.GetLength(0); i++)
        {
            acu += notas[i, asignatura];
        }

        return acu/notas.GetLength(0);
    }

    public void VisualizarNotasAlumno(int[,] notas, int alumno)
    {
        int[] notasAlumno = new int[notas.GetLength(1)];

        for (int i = 0; i < notas.GetLength(1); i++)
        {
            notasAlumno[i] = notas[alumno, i];
        }

        Console.WriteLine($"%3{notasAlumno[0]} %3{notasAlumno[2]} %3{notasAlumno[2]} %3{notasAlumno[3]}");
    }

    public void VisualizarNotasAsignatura(int[,] notas, int asignatura)
    {
        int[] notasAsignauras = new int[notas.GetLength(0)];

        for (int i = 0; i < notas.GetLength(0); i++)
        {
            notasAsignauras[i] = notas[i, asignatura];
        }

        Console.WriteLine($"%3{notasAsignauras[0]} %3{notasAsignauras[2]} %3{notasAsignauras[2]} %3{notasAsignauras[3]}");
    }


}





public enum Asignaturas
{
    Pociones,
    Quidditch,
    Criaturas,
    ArtesOscuras,
}

