using System;
using System.IO;

namespace TemplateMethod.Models
{
    public class ServicioTemplateMethod : AplicacionCentrigrados
    {
        private TextReader _entrada;
        private TextWriter _salida;

        protected override void Iniciar()
        {
            _entrada = Console.In;
            _salida = Console.Out;
        }
        protected override void Trabajar()
        {
            _salida.WriteLine("Introduce un numero en grados farenheit ");
            var grados = _entrada.ReadLine();
            if (string.IsNullOrEmpty(grados))
                SetDone();
            else
            {
                var far = double.Parse(grados);
                var cel = 5.0 / 9.0 * (far - 32);
                _salida.WriteLine("F={0}, C={1}", far, cel);
            }
        }
        protected override void Limpiar()
        {
            Console.Out.WriteLine("Aplicacion Finalizada!!");
        }
    }
}
