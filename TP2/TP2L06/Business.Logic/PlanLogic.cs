using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
#pragma warning disable CS0169 // El campo 'PlanLogic._PlandData' nunca se usa
        private PlanAdapter _PlandData;
#pragma warning restore CS0169 // El campo 'PlanLogic._PlandData' nunca se usa
        public PlanAdapter PlanData { get; set; }
        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }
        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
        }

        public Plan GetOne(int id)
        {
            try
            {
                return PlanData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(Plan pla, BusinessEntity.States est)
        {
            try
            {
                PlanData.Delete(pla, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Plan pl)
        {
            try
            {
                PlanData.Save(pl);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
