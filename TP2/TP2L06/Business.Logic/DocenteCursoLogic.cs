using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        private DocenteCursoAdapter _DocenteCursoData;
        public DocenteCursoAdapter DocenteCursoData
        {
            get { return _DocenteCursoData; }
            set { _DocenteCursoData = value; }
        }

        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }
        public List<DocenteCurso> GetAll()
        {
            try
            {
                return DocenteCursoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public DocenteCurso GetOne(int id)
        {
            try
            {
                return DocenteCursoData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(DocenteCurso cur, BusinessEntity.States est)
        {
            try
            {
                DocenteCursoData.Delete(cur, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public bool Save(DocenteCurso cur)
        {
            try
            {
                var curso = DocenteCursoData.GetOneDictado(cur.IdUsuario, cur.IdCurso);
                if (curso == null)
                {
                    DocenteCursoData.Save(cur);
                    return true;
                }
                return false;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
