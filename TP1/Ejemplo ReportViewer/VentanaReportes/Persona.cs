using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PoryectoReporte
{
    public class Persona
    {
        //Propiedades
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        
        public Persona()
        {
        }
        public Persona(Persona Add)
        {
            Nombre = Add.Nombre;
            Apellido = Add.Apellido;
            Correo = Add.Correo;
        }
    }
}