using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter _EspecialidadData;
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
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
        }

        public Especialidad GetOne(int id)
        {
            return EspecialidadData.GetOne(id);
        }

        public void Delete(int id)
        {
            EspecialidadData.Delete(id);
        }
        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp); //Cuando llega acá el usuario tiene .State = New y deberia tener .State = Modified
        }
    }
}
