using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
#pragma warning disable CS0169 // El campo 'ComisionLogic._ComisionData' nunca se usa
        private ComisionAdapter _ComisionData;
#pragma warning restore CS0169 // El campo 'ComisionLogic._ComisionData' nunca se usa
        public ComisionAdapter ComisionData { get; set; }
        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }
        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", Ex);
                throw ExcepcionManejada;
            }
        }

        public Comision GetOne(int id)
        {
            try
            {
                return ComisionData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }


        public List<Comision> GetComisionesPorCurso(int idCurso)
        {
            try
            {
                return ComisionData.GetComisionesPorCurso(idCurso);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", Ex);
                throw ExcepcionManejada;
            }

        }

        public void Delete(Comision com, BusinessEntity.States est)
        {
            try
            {
                ComisionData.Delete(com, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Comision com)
        {
            try
            {
                ComisionData.Save(com);//Cuando llega acá el usuario tiene .State = New y deberia tener .State = Modified
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
