using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30
{
    class Inscripcion
    {
       
           
         //Traigo datos por csv para crear ele objeto alumno  
        //qué hago con miAlumno??
        //Alumno es estatico tambien?
        int registroValidado;
        int materiaValidada;
        public void IniciarApp()
        {
            const string OpcA = "A";
            const string OpcB = "B";
            const string OpcC = "C";
            const string OpcSalir = "S";
            int count = 0;
            string opcion = "";

            do
            {
                Console.WriteLine("---SISTEMA FCE---");
                Console.WriteLine("A- Ingrese número de registro");
                Console.WriteLine("B- Ingrese el código de la materia");
                Console.WriteLine("C- Inscribir");
                Console.WriteLine("S- Salir");
                opcion = ValidarInput.PedirStrNoVac("Ingrese opción A, B o C");

                switch (opcion)
                {
                    case OpcA:
                        registroValidado = ValidarAlumno.ValAlumno();

                        break;
                    case OpcB:
                        if (registroValidado == 0)
                        {
                            Console.WriteLine("No se encuentra logueado para asignar una materia");
                            Console.ReadKey();
                        }
                        else
                        {
                            materiaValidada = PlanEstudio.ValidarMateria(registroValidado);
                        }
                        break;
                    case OpcC:
                        if (count == 4)
                        {
                            Console.WriteLine("Ya se inscribió en las 3 materias");
                            Console.ReadKey();
                        }
                        else
                        {
                            Curso.AgregarCurso(registroValidado, materiaValidada);
                            count = count + 1;
                        }
                        
                        break;
                    case OpcSalir:
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

            } while (opcion != OpcSalir);


        }

    }
}
