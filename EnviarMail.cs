using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace ConsoleApp30
{
    class EnviarMail
    {
        static public void Mail(int curso, int registro)
        {

            string path = @"c:\Alumno.csv";
            String[] lineas = File.ReadAllLines(path);
            string Nombre="";
            string Apellido = "";
            string Mail = "";

                    
            foreach (var linea in lineas)
            {
                var valores = linea.Split(';');
                if (int.Parse(valores[0]) == registro)
                {
                    Nombre = valores[1];
                    Apellido = valores[2];
                    Mail = valores[5];

                }

            }
            

            string cursomail = Convert.ToString(curso);

            var fromAddress = new MailAddress("economicas.fce.cai@gmail.com", "Economicas FCE");
            var toAddress = new MailAddress(Mail, "To Name");
            string fromPassword = "Trabajon5";
            string subject = "Comprobante de inscripción";
            string body = "El alumno " + Nombre + " "+ Apellido + " con Registro " + registro+ " se ha inscripto correctamente al curso " +cursomail +".";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

            {
                smtp.Send(message);
            }
        }
    }
}
