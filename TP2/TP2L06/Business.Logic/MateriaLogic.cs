using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
#pragma warning disable CS0169 // El campo 'MateriaLogic._MateriaData' nunca se usa
        private MateriaAdapter _MateriaData;
#pragma warning restore CS0169 // El campo 'MateriaLogic._MateriaData' nunca se usa
        public MateriaAdapter MateriaData { get; set; }
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }
        public List<Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
        }

        public Materia GetOne(int id)
        {
            try
            {
                return MateriaData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(Materia mat, BusinessEntity.States est)
        {
            try
            {
                MateriaData.Delete(mat, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Materia mat)
        {
            try
            {
                MateriaData.Save(mat);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
