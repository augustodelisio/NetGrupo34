using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDC = new SqlCommand("select * from docentes_cursos", SqlConn);
                SqlDataReader drDC = cmdDC.ExecuteReader();

                while (drDC.Read())
                {
                    DocenteCurso dc = new DocenteCurso();

                    dc.IdDictado = (int)drDC["id_dictado"];
                    dc.IdCurso = (int)drDC["id_curso"];
                    dc.IdUsuario = (int)drDC["id_usuario"];
                    dc.Cargos = (int)drDC["cargo"];



                    docentesCursos.Add(dc);
                }

                drDC.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista cursos dictados por el docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return docentesCursos;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDC = new SqlCommand("select * from docentes_cursos where id_dictado = @id", SqlConn);
                cmdDC.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDC = cmdDC.ExecuteReader();
                if (drDC.Read())
                {
                    dc.IdDictado = (int)drDC["id_dictado"];
                    dc.IdCurso = (int)drDC["id_curso"];
                    dc.IdUsuario = (int)drDC["id_usuario"];
                    dc.Cargos = (int)drDC["cargo"];
                }
                drDC.Close();
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
            return dc;
        }

        public DocenteCurso GetOneDictado(int idUsuario, int idCurso)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDC = new SqlCommand("select * from docentes_cursos where id_usuario = @idUsuario and id_curso = @idCurso", SqlConn);
                cmdDC.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                cmdDC.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
                SqlDataReader drDC = cmdDC.ExecuteReader();
                if (drDC.Read())
                {
                    dc.IdDictado = (int)drDC["id_dictado"];
                    dc.IdCurso = (int)drDC["id_curso"];
                    dc.IdUsuario = (int)drDC["id_usuario"];
                    dc.Cargos = (int)drDC["cargo"];
                }
                drDC.Close();
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
            return dc;
        }

        public void Delete(DocenteCurso dc, BusinessEntity.States estado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "DELETE from docentes_cursos WHERE id_dictado = @idDictado", SqlConn);

                cmdSave.Parameters.Add("@idDictado", SqlDbType.Int).Value = dc.IdDictado;

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

        public void Save(DocenteCurso dc)
        {
            if ((dc.State == BusinessEntity.States.Deleted) || (dc.State == BusinessEntity.States.Undeleted))
            {
                this.Delete(dc, dc.State);
            }
            else if (dc.State == BusinessEntity.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == BusinessEntity.States.Modified)
            {
                this.Update(dc);
            }
            else
            {
                dc.State = BusinessEntity.States.Unmodified;
            }
        }
        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "Update docentes_cursos SET id_curso = @idcurso, id_usuario = @idusuario, cargo = @cargo, " +
                    "WHERE id_dictado=@idDictado", SqlConn);
                cmdSave.Parameters.Add("@idDictado", SqlDbType.Int).Value = docenteCurso.IdDictado;
                cmdSave.Parameters.Add("@idcurso", SqlDbType.Int).Value = docenteCurso.IdCurso;
                cmdSave.Parameters.Add("@idusuario", SqlDbType.Int).Value = docenteCurso.IdUsuario;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int, 50).Value = docenteCurso.Cargos;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso dictado por el docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO docentes_cursos (id_curso, id_usuario, cargo)" +
                    "values(@idcurso, @idusuario, @cargo)" +
                    "select @@identity", SqlConn);

                cmdSave.Parameters.Add("@idcurso", SqlDbType.Int).Value = dc.IdCurso;
                cmdSave.Parameters.Add("@idusuario", SqlDbType.Int).Value = dc.IdUsuario;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int, 50).Value = dc.Cargos;

                dc.IdDictado = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al inscribir al docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
