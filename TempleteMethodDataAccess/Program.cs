using System;
using TempleteMethodDataAccess.Models;

namespace TempleteMethodDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var amigos = new AmigosDataAccess();
            //amigos.AgregarAmigo(new Amigo {direccion = "", fecnac =  System.DateTime.Now, idamigo = 0, nombre = "jose", telefono = "13456789"});
            amigos.ObtenerAmigos();
            Console.ReadLine();
        }
    }
}
