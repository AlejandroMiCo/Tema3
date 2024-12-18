using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    abstract class Persona//TODO stackoverflow
    {

        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        private int edad;
        public int Edad
        {
            set
            {
                if (value < 0)
                    edad = 0;
                else
                {
                    
                edad = value;
                }
            }
            get { return edad; }
        }

        private string dni;
        public string Dni   
        {
            set
            {
                dni = value;
                return;
            }
            get {
                return dni + (DniConver(Convert.ToInt32(dni)));            
            }
        }

        public Persona(string nombre, string apellidos, int edad, string dni)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Dni = dni;
        }

        public Persona()
            : this("", "", 0, "") { }

        public virtual void AsignarDatos()
        {
            Nombre = PedirDatos("Nombre");
            Apellidos = PedirDatos("Apellidos");
            Edad = Convert.ToInt32(PedirDatos("Edad"));
            Dni = PedirDatos("Dni");
        }

        public virtual void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre} \nAepllidos: {Apellidos} \nEdad: {Edad.ToString()} \nDni: {Dni}");
        }

        static string DniConver(int dniNumbers)
        {
            //Cargamos los digitos de control
            string control = "TRWAGMYFPDXBNJZSQVHLCKE";
            int letra = dniNumbers % 23;
            return control[letra].ToString();
        }

        public abstract double Hacienda();

        public static string PedirDatos(string valor)
        {
            Console.WriteLine($"Introduzca el valor para {valor}");
            return Console.ReadLine();
        }
    }
}
