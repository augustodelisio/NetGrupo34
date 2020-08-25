using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {
        private PersonaAdapter _PersonaData;
        public PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }
        public List<Persona> GetAll()
        {
            try
            {
                return PersonaData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public Persona GetOne(int id)
        {
            try
            {
                return PersonaData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(Persona per, BusinessEntity.States est)
        {
            try
            {
                PersonaData.Delete(per, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Persona per)
        {
            try
            {
                PersonaData.Save(per);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
