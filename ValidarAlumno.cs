using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp30
{
    static class ValidarAlumno
    {
        
        private const int valorMinimo = 100000;
        private const int valorMaximo = 900000;

        static public int ValAlumno()
        {
            int registro = 0;
            bool resultado;
            bool resultado2;
            string clave;

            registro = ValidarInput.PedirInt("Ingrese su nro de registro", valorMinimo, valorMaximo);
            Persona alumno = new Persona();
            

            resultado = Validaciones(registro);
            if (resultado)
            {

                Console.WriteLine("Ingrese su clave");
                clave = Console.ReadLine();
                resultado2 = ValidarPass(clave);

                if (resultado2)
                {
                    alumno.Nroegistro = registro;
                    alumno.Nombre = DevolverNombre(registro);
                    Console.WriteLine("Bienvenido " + alumno.Nombre);
                    Console.WriteLine("Su registro " + alumno.Nroegistro + " ha sido validado");
                    Console.ReadKey();
                    return registro;
                }
                else
                {
                    Console.WriteLine("Su contraseña es incorrecta");
                }
                
            }
            else
            {
                Console.WriteLine("Su registro es incorrecto");
                Console.ReadKey();
                return 0;
            }
            return registro;
        }
        static bool Validaciones(int registro)
        {
            string path = @"c:\Alumno.csv";
            String[] lineas = File.ReadAllLines(path);
            bool ok = false;

            foreach (var linea in lineas)
            {
                var valores = linea.Split(';');
                if (int.Parse(valores[0]) == registro && valores[3] == "Activo")
                {
                    ok = true;
                }
                
            }
            return ok;
        }
        static string DevolverNombre(int registro)
        {
            string path = @"c:\Alumno.csv";
            String[] lineas = File.ReadAllLines(path);
            string Nombre="";

            foreach (var linea in lineas)
            {
                var valores = linea.Split(';');
                if (int.Parse(valores[0]) == registro && valores[3] == "Activo")
                {
                    Nombre = valores[1];
                }
                
            }
            return Nombre;
        }

        static bool ValidarPass(string clave)
        {
            string path = @"c:\Alumno.csv";
            String[] lineas = File.ReadAllLines(path);
            bool ok = false;

            foreach (var linea in lineas)
            {
                var valores = linea.Split(';');
                if (valores[4] == clave)
                {
                    ok = true;
                }

            }
            return ok;
        }

    }
        
    
}
