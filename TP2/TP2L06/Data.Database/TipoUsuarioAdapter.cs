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
    public class TipoUsuarioAdapter : Adapter
    {
        public List<TipoUsuario> GetAll()
        {
            List<TipoUsuario> tipos_usuarios = new List<TipoUsuario>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdTiposUsuarios = new SqlCommand("select * from tipos_usuarios", SqlConn);
                SqlDataReader drTiposUsuarios = cmdTiposUsuarios.ExecuteReader();

                while (drTiposUsuarios.Read())
                {
                    TipoUsuario tu = new TipoUsuario();

                    tu.IdTipoUsuario = (int)drTiposUsuarios["id_tipo_usuario"];
                    tu.Descripcion = (string)drTiposUsuarios["descripcion"];
                    tu.Habilitado = (bool)drTiposUsuarios["habilitado"];

                    tipos_usuarios.Add(tu);
                }

                drTiposUsuarios.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de tipos de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return tipos_usuarios;
        }

        public TipoUsuario GetOne(int ID)
        {
            TipoUsuario tu = new TipoUsuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdTiposUsuarios = new SqlCommand("select * from tipos_usuarios where id_tipo_usuario = @id", SqlConn);
                cmdTiposUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drTiposUsuarios = cmdTiposUsuarios.ExecuteReader();
                if (drTiposUsuarios.Read())
                {
                    tu.IdTipoUsuario = (int)drTiposUsuarios["id_tipo_usuario"];
                    tu.Descripcion = (string)drTiposUsuarios["descripcion"];
                    tu.Habilitado = (bool)drTiposUsuarios["habilitado"];
                }
                drTiposUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de tipo de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return tu;
        }

        public void Delete(TipoUsuario tipo_usuario, BusinessEntity.States estado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE tipos_usuarios SET descripcion = @descripcion, habilitado = @habilitado " +
                    "WHERE id_tipo_usuario=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = tipo_usuario.IdTipoUsuario;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = tipo_usuario.Descripcion;
                if (estado == BusinessEntity.States.Deleted)
                    { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = false; }
                else
                    { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = true; }
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar tipo de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(TipoUsuario tipo_usuario)
        {
            if ((tipo_usuario.State == BusinessEntity.States.Deleted) || (tipo_usuario.State == BusinessEntity.States.Undeleted))
            {
                this.Delete(tipo_usuario, tipo_usuario.State);
            }
            else if (tipo_usuario.State == BusinessEntity.States.New)
            {
                this.Insert(tipo_usuario);
            }
            else if (tipo_usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(tipo_usuario);
            }
            else
            {
                tipo_usuario.State = BusinessEntity.States.Unmodified;
            }
        }
        protected void Update(TipoUsuario tipo_usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE tipos_usuarios SET descripcion = @descripcion, habilitado = @habilitado " +
                    "WHERE id_tipo_usuario=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = tipo_usuario.IdTipoUsuario;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = tipo_usuario.Descripcion;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = tipo_usuario.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del tipo de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(TipoUsuario tipo_usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO tipos_usuarios(descripcion, habilitado) " +
                    "values(@descripcion, @habilitado) " +
                    "select @@identity", SqlConn);
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = tipo_usuario.Descripcion;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = tipo_usuario.Habilitado;
                tipo_usuario.IdTipoUsuario = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear tipo de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
