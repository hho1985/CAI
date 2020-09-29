using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp30
{
    static class PlanEstudio
    {
        static public int ValidarMateria(int registro)
        {
            int materia;
            bool resultado;
            //imprimir lista

            materia = ValidarInput.PedirInt("Por favor escriba el codigo de la materia",0,100);
            resultado = ValidacionPlan(materia);
            if (resultado)
            {
                Console.WriteLine("Se encuentra una vacante");
                return materia;
            }
            else
            {
                Console.WriteLine("No se encuentra vacante para el curso seleccionado");
                return 0;
            }
            
        }
        static public bool ValidacionPlan(int materia)
        {
            
            bool ok = false;
            string path = @"c:\Cursos.csv";
            String[] lineas = File.ReadAllLines(path);
            bool ok2 = false;

            foreach (var linea in lineas)
            {
                var valores = linea.Split(',');

                int a = int.Parse(valores[0]);
                int b = int.Parse(valores[3]);
                if (a == materia && b > 0)
                {
                    ok2 = true;
                }
                
            }
            return ok2;
        }
    }
}
