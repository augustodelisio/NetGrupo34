using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para generar el archivo agendaxml.xml con los datos de agenda.txt");
            Console.ReadKey();
            EscribirXML();
            Console.WriteLine("Archivo agendaxml.xml generado correctamente\n\nPresione una tecla para ver su contenido");
            Console.ReadKey();
            Console.WriteLine();
            LeerXML();
            Console.ReadKey();
        }

        private static void Leer()
        {
            /* LECTOR DE ARCHIVOS
            var lector = new FileStream("agenda.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            while (lector.Length > lector.Position)
            {
                Console.Write((char)lector.ReadByte());
            }
            lector.Close();
            Console.ReadKey();*/

            /*LECTOR DE TEXTO*/
            var lector = File.OpenText("agenda.txt");
            string linea;
            Console.WriteLine("Nombre\t\tApellido\te-mail\t\t\t\tTelefono");
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string[] valores = linea.Split(';');
                    Console.WriteLine("{0}\t\t{1}\t{2}\t\t{3}", valores[0], valores[1], valores[2], valores[3]);
                }
            }
            while (linea != null);
            lector.Close();
        }

        private static void Escribir()
        {
            var escritor = File.AppendText("agenda.txt");
            Console.WriteLine("Ingrese nuevos contactos");
            string rta = "S";
            while (rta == "S")
            {
                Console.Write("Ingrese Nombre\n");
                string nombre = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese Apellido\n");
                string apellido = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese E-Mail\n");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese Telefono\n");
                string telefono = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                escritor.WriteLine(nombre + ";" + apellido + ";" + email + ";" + telefono);
                Console.Write("Desea ingresar otro contacto? (S/N)");
                rta = Console.ReadLine().ToUpper();
            }
            escritor.Close();
        }

        private static void LeerXML()
        {
            var lectorXML = new XmlTextReader("agendaxml.xml");

            string tagAnterior = "";
            while (lectorXML.Read())
            {
                if (lectorXML.NodeType == XmlNodeType.Element)
                {
                    tagAnterior = lectorXML.Name;
                }
                else if (lectorXML.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(tagAnterior + ": " + lectorXML.Value);
                }
            }
            lectorXML.Close();
        }

        private static void EscribirXML()
        {
            var escritorXML = new XmlTextWriter("agendaxml.xml", null);
            escritorXML.Formatting = Formatting.Indented;
            escritorXML.WriteStartDocument(true);
            escritorXML.WriteStartElement("DocumentElement");//No debe contener espacios (da error)

            var lector = File.OpenText("agenda.txt");
            string linea;
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string[] valores = linea.Split(';');
                    escritorXML.WriteStartElement("Contactos");
                    escritorXML.WriteStartElement("Nombre");
                    escritorXML.WriteValue(valores[0]);
                    escritorXML.WriteEndElement(); //Cerramos tag de nombre
                    escritorXML.WriteStartElement("Apellido");
                    escritorXML.WriteValue(valores[1]);
                    escritorXML.WriteEndElement(); //Cerramos tag de apellido
                    escritorXML.WriteStartElement("Email");
                    escritorXML.WriteValue(valores[2]);
                    escritorXML.WriteEndElement(); //Cerramos tag de email
                    escritorXML.WriteStartElement("Telefono");
                    escritorXML.WriteValue(valores[3]);
                    escritorXML.WriteEndElement(); //Cerramos tag de telefono
                    escritorXML.WriteEndElement(); //Cerramos tag de contactos
                }
            }
            while (linea != null);
            escritorXML.WriteEndElement();
            escritorXML.WriteEndDocument();
            escritorXML.Close();

            lector.Close();
        }
    }
}
