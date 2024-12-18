using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Empleado : Persona
    {
        private double salario;
        public double Salario
        {
            get { return salario; }
            set
            {
                salario = value;

                if (salario < 600)
                {
                    irpf = 7;
                }
                else if (600 < salario && salario < 3000)
                {
                    irpf = 15;
                }
                else
                {
                    irpf = 20;
                }
            }
        }

        public int irpf;
        private int Irpf
        {
            get { return irpf; }
        }
        private string numero;
        public string Numero
        {
            set { numero = value; }
            get { return $"+34 {numero}"; }
        }

        public Empleado(
            string nombre,
            string apellidos,
            int edad,
            string dni,
            double salario,
            string numero
        )
            : base(nombre, apellidos, edad, dni)
        {
            this.Salario = salario;
            this.Numero = numero;
        }

        public Empleado()
            : this("", "", 0, "", 0, "") { }

        public override void MostrarDatos()
        {
            base.MostrarDatos();
            Console.WriteLine($"Salario: {Salario} \nIrpf: {irpf} \nNumero: {Numero}");
        }

        public void MostrarDato(int valor)
        {
            switch (valor)
            {
                case 0:
                    Console.WriteLine(Nombre);
                    break;
                case 1:
                    Console.WriteLine(Apellidos);
                    break;
                case 2:
                    Console.WriteLine(Edad.ToString());
                    break;
                case 3:
                    Console.WriteLine(Dni);
                    break;
                case 4:
                    Console.WriteLine(Salario.ToString());
                    break;
                case 5:
                    Console.WriteLine(Irpf.ToString() + "%");
                    break;
                case 6:
                    Console.WriteLine(Numero);
                    break;
                default:
                    Console.WriteLine("No se ha encontrado la propiedad indicada");
                    break;
            }
        }

        public override double Hacienda()
        {
            return Irpf * Salario / 100;
        }
    }
}
