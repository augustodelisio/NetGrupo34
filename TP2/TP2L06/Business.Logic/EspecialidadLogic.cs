using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
#pragma warning disable CS0169 // El campo 'EspecialidadLogic._EspecialidadData' nunca se usa
        private EspecialidadAdapter _EspecialidadData;
#pragma warning restore CS0169 // El campo 'EspecialidadLogic._EspecialidadData' nunca se usa
        public EspecialidadAdapter EspecialidadData { get; set; }
        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }
        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public Especialidad GetOne(int id)
        {
            try
            {
                return EspecialidadData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(Especialidad esp, BusinessEntity.States est)
        {
            try
            {
                EspecialidadData.Delete(esp, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Especialidad esp)
        {
            try
            {
                EspecialidadData.Save(esp);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
