using System;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private int _IdPersona;
        public int IdPersona
        {
            get { return _IdPersona; }
            set { _IdPersona = value; }
        }

        private string _Apellido;
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private DateTime _FechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }
        private int _IdPlan;
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _Telefono;
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private bool _Habilitado;
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }
#pragma warning disable CS0169 // El campo 'Persona._NombreYApellido' nunca se usa
        private string _NombreYApellido;
#pragma warning restore CS0169 // El campo 'Persona._NombreYApellido' nunca se usa
        public string NombreYApellido
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }
    }

}
