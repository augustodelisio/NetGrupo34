using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", SqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();

                    com.IdComision = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.Habilitado = (bool)drComisiones["habilitado"];

                    comisiones.Add(com);
                }

                drComisiones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision = @id", SqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    com.IdComision = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.Habilitado = (bool)drComisiones["habilitado"];
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return com;
        }
        public List<Comision> GetComisionesPorCurso(int idMateria)
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {

                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("" +
                    "SELECT DISTINCT com.desc_comision, com.anio_especialidad, com.id_comision " +
                    "FROM cursos cur " +
                    "INNER JOIN comisiones com ON com.id_comision = cur.id_comision " +
                    "WHERE cur.id_materia = @idMateria and com.habilitado='true'", SqlConn);

                cmdComisiones.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;


                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();

                    com.IdComision = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    //com.Habilitado = (bool)drComisiones["habilitado"];

                    comisiones.Add(com);
                }

                drComisiones.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return comisiones;
        }

        public void Delete(Comision comision, BusinessEntity.States estado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE comisiones SET desc_comision = @desc_comision, habilitado = @habilitado, anio_especialidad = @anio_especialidad " +
                    "WHERE id_comision=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.IdComision;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                if (estado == BusinessEntity.States.Deleted)
                { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = false; }
                else
                { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = true; }
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar Comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted || (comision.State == BusinessEntity.States.Undeleted))
            {
                this.Delete(comision, comision.State);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            else
            {
                comision.State = BusinessEntity.States.Unmodified;
            }
        }
        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE comisiones SET desc_comision = @desc_comision, habilitado = @habilitado, anio_especialidad = @anio_especialidad " +
                    "WHERE id_comision=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.IdComision;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = comision.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la Comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO comisiones(desc_comision, habilitado, anio_especialidad) " +
                    "values(@desc_comision, @habilitado, @anio_especialidad) " +
                    "select @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = comision.Habilitado;
                comision.IdComision = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
