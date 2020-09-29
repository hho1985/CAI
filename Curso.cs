using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ConsoleApp30
{
    static class Curso
    {
        static public void AgregarCurso(int registro, int materia)
        {
            
            if (materia == 0)
            {
                Console.WriteLine("No se puede realizar la inscripción ya que no se encuentran vacantes");
                Console.ReadKey();
            }

            

            else if (ValidarInscripto(registro, materia))
            {
                Console.WriteLine("Ya se encuentra inscripto en la materia");
                Console.ReadKey();
            }

            else
            {
                string path1 = @"c:\Inscripciones.csv";

                string[] lineas = { "", "" };

                StreamWriter sw = File.AppendText(path1);
                sw.WriteLine(registro + "," + materia);
                sw.Close();
                Console.WriteLine("Su inscripción se ha guardado correctamente.");
                ActualizarVacante(materia);

                EnviarMail.Mail(materia, registro);
                Console.WriteLine("Se ha enviado un comprobante a su casilla de correo.");
                Console.ReadKey();
                Console.WriteLine("Presione S para salir");


                
            }
           
            
        }

        static public void ActualizarVacante(int materia)
        {
            int a; //Numero materia csv
            int b; //Disponibilidad actual
            int c; //Disponibildiad actual -1

            string path = @"c:\Cursos.csv";
            //Leer Materia            
            String[] lineas = File.ReadAllLines(path);
            
            foreach (var linea in lineas)
            {
                var valores = linea.Split(',');
                string i;
                string j;
                a = int.Parse(valores[0]);
                b = int.Parse(valores[3]);

                if (a == materia )
                {
                    c = b - 1;
                    i = valores[0] + "," + valores[1] + "," + valores[2] + "," + b.ToString();
                    j = valores[0] + "," + valores[1] + "," + valores[2] + "," + c.ToString();
                    string textoModificado = File.ReadAllText(path);
                    
                    Console.ReadKey();
                    textoModificado = textoModificado.Replace(i, j);
                    File.WriteAllText(path, textoModificado);    
                    break;                
                }
                
                   
         
            }                        
            
        }

        static bool ValidarInscripto(int registro, int materia)
        {
            string path = @"c:\Inscripciones.csv";
            String[] lineas = File.ReadAllLines(path);
            bool ok = false;
            string a;
            string b;
            a = Convert.ToString(registro);
            b=  Convert.ToString(materia);
            foreach (var linea in lineas)
            {
               
                var valores = linea.Split(',');
               
                if (valores[0] == a && valores[1] == b)
                {
                    ok = true;
                }

            }
            return ok;
        }


    }
}
