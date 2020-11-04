using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter:Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.IdCurso = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    //cur.Descripcion = (string)drCursos["descripcion"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    //cur.Habilitado = (bool)drCursos["habilitado"];

                    cursos.Add(cur);
                }

                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso = @id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.IdCurso = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Descripcion = (string)drCursos["descripcion"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.Habilitado = (bool)drCursos["habilitado"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public Curso BuscarCursoPorMateriaComision(int idMateria, int idComision)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select id_curso from cursos " +
                    "where id_materia = @idMateria and id_comision = @idComision and anio_calendario = year(getdate()) ", SqlConn);
                cmdCursos.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;
                cmdCursos.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.IdCurso = (int)drCursos["id_curso"];

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public void Delete(Curso curso, BusinessEntity.States estado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET descripcion = @descripcion, anio_calendario = @anio_calendario, cupo = @cupo, " +
                    "id_materia = @id_materia, id_comision = @id_comision, habilitado = @habilitado " +
                    "WHERE id_curso=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.IdCurso;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
                if (estado == BusinessEntity.States.Deleted)
                { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = false; }
                else
                { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = true; }
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if ((curso.State == BusinessEntity.States.Deleted) || (curso.State == BusinessEntity.States.Undeleted))
            {
                this.Delete(curso, curso.State);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            else
            {
                curso.State = BusinessEntity.States.Unmodified;
            }
        }
        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET descripcion = @descripcion, anio_calendario = @anio_calendario, cupo = @cupo, " +
                    "id_materia = @id_materia, id_comision = @id_comision, habilitado = @habilitado " +
                    "WHERE id_curso=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.IdCurso;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = curso.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO cursos(anio_calendario, cupo, id_materia, id_comision, descripcion, habilitado)" +
                    "values(@anio_calendario, @cupo, @id_materia, @id_comision, @descripcion, @habilitado)" +
                    "select @@identity", SqlConn);
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = curso.Habilitado;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
