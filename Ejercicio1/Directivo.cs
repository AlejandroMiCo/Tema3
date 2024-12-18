using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Directivo : Persona, IPastaGansa
    {
        public string Department { get; set; }

        public double porcentajeDeBeneficios;
        public double PorcentajeBeneficios { get { return porcentajeDeBeneficios; } }

        private double PastaGanada {  get; set; }
        private int personas;
        public int Personas
        {
            get { return personas; }
            set
            {
                personas = value;
                switch (personas)
                {
                    case int x when x <= 10:
                        porcentajeDeBeneficios = 2;
                        break;

                    case int x when x > 10 && x < 50:
                        porcentajeDeBeneficios = 3.5;
                        break;
                    default:
                        porcentajeDeBeneficios = 4;
                        break;
                }
            }
        }

        public Directivo(string nombre, string apellidos, int edad, string dni, string department, int personas)
            : base(nombre, apellidos, edad, dni)
        {

            this.Department = department;
        
            this.Personas = personas;
        }



        public override void MostrarDatos()
        {
            base.MostrarDatos();
            Console.WriteLine($"Departamento: {Department} \nBeneficios: {porcentajeDeBeneficios} \nPersonas: {Personas} \n");
        }

        public override void AsignarDatos()
        {
            base.AsignarDatos();
            Department = Persona.PedirDatos("Departamento");
            Personas = Convert.ToInt32(Persona.PedirDatos("Personas"));
        }

        public static Directivo operator --(Directivo d1)
        {
            d1.porcentajeDeBeneficios = d1.porcentajeDeBeneficios - 1;

            if (d1.porcentajeDeBeneficios < 0)
            {
                d1.porcentajeDeBeneficios = 0;
            }

            return d1;
        }

        public override double Hacienda()
        {
            return PastaGanada * 30 / 100;
        }

        public double ganarPasta(double beneficios)
        {
            Directivo dire = this;

            if (beneficios < 0)
            {
                dire--;
                return 0;
            }
            else
            {
                double result = beneficios * porcentajeDeBeneficios / 100;
                PastaGanada += result;
                return result;
            }
        }
    }
}
