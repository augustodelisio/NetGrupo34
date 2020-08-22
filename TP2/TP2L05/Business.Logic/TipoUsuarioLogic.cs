using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class TipoUsuarioLogic : BusinessLogic
    {
        private TipoUsuarioAdapter _TipoUsuarioData;
        public TipoUsuarioAdapter TipoUsuarioData
        {
            get { return _TipoUsuarioData; }
            set { _TipoUsuarioData = value; }
        }

        public TipoUsuarioLogic()
        {
            TipoUsuarioData = new TipoUsuarioAdapter();
        }
        public List<TipoUsuario> GetAll()
        {
            try
            {
                return TipoUsuarioData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de tipos de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public TipoUsuario GetOne(int id)
        {
            return TipoUsuarioData.GetOne(id);
        }

        public void Delete(TipoUsuario tus, BusinessEntity.States est)
        {
            TipoUsuarioData.Delete(tus, est);
        }
        public void Save(TipoUsuario tus)
        {
            TipoUsuarioData.Save(tus);
        }
    }
}
