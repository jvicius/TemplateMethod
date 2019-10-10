using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethod.Models;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProgramaPrincipal();
            var servicio = new ServicioTemplateMethod();
            servicio.EjecutarAplicacion();
        }

        private static void ProgramaPrincipal()
        {
            var done = false;
            while (!done)
            {
                Console.WriteLine("Introduce un numero en grados farenheit ");
                var grados = Console.ReadLine();
                if (string.IsNullOrEmpty(grados))
                    done = true;
                else
                {
                    var far = Double.Parse(grados);
                    var cel = 5.0 / 9.0 * (far - 32);
                    Console.WriteLine("F={0} , C={1}", far, cel);
                }
            }
            Console.Out.WriteLine("Aplicacion Finalizada!!");
        }
    }
}
