using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter _PlanData;
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
            return PlanData.GetOne(id);
        }

        public void Delete(int id)
        {
            PlanData.Delete(id);
        }
        public void Save(Plan pl)
        {
            PlanData.Save(pl);
        }
    }
}
