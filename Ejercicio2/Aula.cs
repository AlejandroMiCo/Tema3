using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Asignaturas
{
    Pociones = 0,
    Quidditch,
    Criaturas,
    ArtesOscuras,
}
class Aula
{
    public int[,] notas;
    public string[] alumnos;
    public string this[int indice]
    {
        set
        {
            alumnos[indice] = value;
        }
        get
        {
            return alumnos[indice];
        }

    }

    //????
    public int GetAlumno(string alumno)
    {
        for (int j = 0; j < alumnos.Length; j++)
        {
            if (alumnos[j] == alumno)
            {
                return j;
            }
        }

        return -1;
    }


    public Aula(String[] nombres)
    {
        alumnos = nombres;

        for (int i = 0; i < nombres.Length; i++)
        {
            Console.WriteLine(i);
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

    public void RellenaNotas()
    {
        Random rd = new Random();
        for (int i = 0; i < notas.GetLength(0); i++)
        {
            for (int j = 0; j < notas.GetLength(1); j++)
            {
                notas[i, j] = rd.Next(0,11); 
            }
        }
    }

    public int CalcularMediasGlobales()
    {
        int acu = 0;

        foreach (var nota in notas)
        {
            acu += nota;
        }

        return acu / notas.Length;
    }

    public int CalcularMediasAlumno(int alumno)
    {
        int acu = 0;
        for (int j = 0; j < notas.GetLength(1); j++)
        {
            acu += notas[alumno, j];
        }

        return acu / notas.GetLength(1);
    }

    public int MediaDeUnaAsignatura(int asignatura)
    {
        int acu = 0;

        for (int i = 0; i < notas.GetLength(0); i++)
        {
            acu += notas[i, asignatura];
        }

        return acu / notas.GetLength(0);
    }
    public void NotasMaxAndMin(int alumno, out int max, out int min)
    {
        max = notas[alumno, 0];
        min = notas[alumno, 0];

        for (int i = 0; i < notas.GetLength(0); i++)
        {
            if (notas[alumno, i] > max)
            {
                max = notas[alumno, i];
            }

            if (notas[alumno, i] < min)
            {
                min = notas[alumno, i];
            }
        }
    }
}