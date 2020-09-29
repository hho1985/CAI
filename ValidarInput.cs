using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    static class ValidarInput
    {
        public static int PedirInt(string mensaje, int min, int max)
        {
            int valor;
            bool valido = false;
            string mensError = "Debe ingresar un valor entre " + min + " y " + max;

            do
            {
                Console.WriteLine(mensaje);
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine(mensError);
                }
                else
                {
                    if (valor < min || valor > max)
                    {
                        Console.WriteLine(mensError);
                    }
                    else
                    {
                        valido = true;
                    }
                }
            } while (!valido);

            return valor;
        }

        public static string PedirStrNoVac(string mensaje)
        {
            string valor;
            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine().ToUpper();
                if (valor == "")
                {
                    Console.WriteLine("No puede ser vacío");
                }
            } while (valor == "");

            return valor;
        }

        public static string PedirSoN(string mensaje)
        {
            string valor;
            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine().ToUpper();
                if (valor != "S" && valor != "N")
                {
                    Console.WriteLine("Debe ser S o N");
                }
            } while (valor != "S" && valor != "N");

            return valor;
        }
    }
}
