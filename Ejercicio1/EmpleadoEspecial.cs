using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class EmpleadoEspecial : Empleado, IPastaGansa
    {
        public override double Hacienda()
        {
            return base.Hacienda() * 1.005;
        }

        public EmpleadoEspecial(
            string nombre,
            string apellidos,
            int edad,
            string dni,
            double salario,
            string numero
        )
            : base(nombre, apellidos, edad, dni, salario, numero) { }

        public double ganarPasta(double beneficios)
        {
            return beneficios * 0.005;
        }
    }
}
