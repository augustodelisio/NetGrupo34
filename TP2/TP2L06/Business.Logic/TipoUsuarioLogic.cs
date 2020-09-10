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
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public TipoUsuario GetOne(int id)
        {
            try
            {
                return TipoUsuarioData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(TipoUsuario tus, BusinessEntity.States est)
        {
            try
            {
                TipoUsuarioData.Delete(tus, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(TipoUsuario tus)
        {
            try
            {
                TipoUsuarioData.Save(tus);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
}
    }
}
