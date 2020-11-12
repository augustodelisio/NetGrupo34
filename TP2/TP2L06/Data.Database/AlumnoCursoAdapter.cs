using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Data.Database
{
    public class AlumnoCursoAdapter : Adapter
    {
        public List<AlumnoCurso> GetAll()
        {
            List<AlumnoCurso> cursos = new List<AlumnoCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from alumnos_cursos", SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    AlumnoCurso cur = new AlumnoCurso();

                    cur.IdInscripcion = (int)drCursos["id_inscripcion"];
                    cur.IdUsuario = (int)drCursos["id_usuario"];
                    cur.IdCurso = (int)drCursos["id_curso"];
                    cur.Condicion = (string)drCursos["Condicion"];
                    cur.Nota = (int)drCursos["Nota"];


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

        public AlumnoCurso GetOne(int ID)
        {
            AlumnoCurso cur = new AlumnoCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from alumnos_cursos where id_inscripcion = @id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.IdInscripcion = (int)drCursos["id_inscripcion"];
                    cur.IdUsuario = (int)drCursos["id_usuario"];
                    cur.IdCurso = (int)drCursos["id_curso"];
                    cur.Condicion = (string)drCursos["Condicion"];
                    cur.Nota = (int)drCursos["Nota"];
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

        public AlumnoCurso GetOneDictado(int idUsuario, int idCurso)
        {
            AlumnoCurso cur = new AlumnoCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from alumnos_cursos where id_usuario = @idUsuario and id_curso = @idCurso", SqlConn);
                cmdCursos.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                cmdCursos.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.IdInscripcion = (int)drCursos["id_inscripcion"];
                    cur.IdUsuario = (int)drCursos["id_usuario"];
                    cur.IdCurso = (int)drCursos["id_curso"];
                    cur.Condicion = (string)drCursos["condicion"];
                    cur.Nota = (int)drCursos["nota"];
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

        public void Delete(AlumnoCurso curso, BusinessEntity.States estado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "DELETE from alumnos_cursos WHERE id_inscripcion = @idinscripcion", SqlConn);

                cmdSave.Parameters.Add("@idinscripcion", SqlDbType.Int).Value = curso.IdInscripcion;

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


        public void Save(AlumnoCurso curso)
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
        protected void Update(AlumnoCurso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "Update alumnos_cursos SET id_curso = @idcurso, id_usuario = @idusuario, condicion = @condicion, " +
                    "nota = @nota " +
                    "WHERE id_inscripcion=@idinscripcion", SqlConn);
                cmdSave.Parameters.Add("@idinscripcion", SqlDbType.Int).Value = curso.IdInscripcion;
                cmdSave.Parameters.Add("@idcurso", SqlDbType.Int).Value = curso.IdCurso;
                cmdSave.Parameters.Add("@idusuario", SqlDbType.Int).Value = curso.IdUsuario;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = curso.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = curso.Nota;
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
        protected void Insert(AlumnoCurso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO alumnos_cursos (id_curso, id_usuario, condicion, nota)" +
                    "values(@idcurso, @idusuario, @condicion, @nota)" +
                    "select @@identity", SqlConn);

                cmdSave.Parameters.Add("@idcurso", SqlDbType.Int).Value = curso.IdCurso;
                cmdSave.Parameters.Add("@idusuario", SqlDbType.Int).Value = curso.IdUsuario;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = curso.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = curso.Nota;

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

        public int getCantAlumnos(int idCurso)
        {
            return GetAll().Where(x => x.IdCurso == idCurso).ToList().Count();
        }
    }
}
