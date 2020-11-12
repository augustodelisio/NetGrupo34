using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Legajo = (int)drUsuarios["legajo"];
                    usr.IdTipoUsuario = (int)drUsuarios["id_tipo_usuario"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    usuarios.Add(usr);
                }

                drUsuarios.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Legajo = (int)drUsuarios["legajo"];
                    usr.IdTipoUsuario = (int)drUsuarios["id_tipo_usuario"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(Usuario usuario, BusinessEntity.States estado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, legajo = @legajo, id_tipo_usuario = @id_tipo_usuario, id_persona = @id_persona " +
                    "WHERE id_usuario=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = usuario.Legajo;
                cmdSave.Parameters.Add("@id_tipo_usuario", SqlDbType.Int).Value = usuario.IdTipoUsuario;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                if (estado == BusinessEntity.States.Deleted)
                { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = false; }
                else
                { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = true; }
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if ((usuario.State == BusinessEntity.States.Deleted) || (usuario.State == BusinessEntity.States.Undeleted))
            {
                this.Delete(usuario, usuario.State);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            else
            {
                usuario.State = BusinessEntity.States.Unmodified;
            }
        }
        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave," +
                    "habilitado = @habilitado, legajo = @legajo, id_tipo_usuario = @id_tipo_usuario, id_persona = @id_persona " +
                    "WHERE id_usuario=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = usuario.Legajo;
                cmdSave.Parameters.Add("@id_tipo_usuario", SqlDbType.Int).Value = usuario.IdTipoUsuario;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO usuarios(nombre_usuario, clave, habilitado, legajo, id_tipo_usuario, id_persona)" +
                    "values(@nombre_usuario, @clave, @habilitado, @legajo, @id_tipo_usuario, @id_persona)" +
                    "select @@identity", SqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = usuario.Legajo;
                cmdSave.Parameters.Add("@id_tipo_usuario", SqlDbType.Int).Value = usuario.IdTipoUsuario;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
