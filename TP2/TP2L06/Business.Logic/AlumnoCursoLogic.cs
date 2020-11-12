using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;


namespace Business.Logic
{
    public class AlumnoCursoLogic
    {
        private AlumnoCursoAdapter _AlumnoCursoData;
        public AlumnoCursoAdapter AlumnoCursoData
        {
            get { return _AlumnoCursoData; }
            set { _AlumnoCursoData = value; }
        }

        public AlumnoCursoLogic()
        {
            AlumnoCursoData = new AlumnoCursoAdapter();
        }
        public List<AlumnoCurso> GetAll()
        {
            try
            {
                return AlumnoCursoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public AlumnoCurso GetOne(int id)
        {
            try
            {
                return AlumnoCursoData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(AlumnoCurso cur, BusinessEntity.States est)
        {
            try
            {
                AlumnoCursoData.Delete(cur, est);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public bool Save(AlumnoCurso cur)
        {

            try
            {
                if (cur.State == BusinessEntity.States.Modified)
                {
                    AlumnoCursoData.Save(cur);
                    return true;
                }
                else
                {
                    var curso = AlumnoCursoData.GetOneDictado(cur.IdUsuario, cur.IdCurso);
                    if (curso.IdCurso == 0)
                    {
                        AlumnoCursoData.Save(cur);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
        public int getCantAlumnos(int idCurso)
        {
            try
            {
                return AlumnoCursoData.getCantAlumnos(idCurso);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de conexión con la base de datos. Consulte a su proveedor de servicios.", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
