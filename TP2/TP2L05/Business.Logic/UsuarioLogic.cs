using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        private UsuarioAdapter _UsuarioData;
        public UsuarioAdapter UsuarioData 
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; } 
        }  

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();               
        }
        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public Usuario GetOne(int id)
        {
            try
            {
                return UsuarioData.GetOne(id);
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(Usuario usu, BusinessEntity.States est)
        {
            try
            {
                UsuarioData.Delete(usu, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Usuario usu)
        {
            try
            {
                UsuarioData.Save(usu);
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
}
    }
}
