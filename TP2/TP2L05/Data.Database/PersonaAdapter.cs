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
    public class PersonaAdapter:Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", SqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.IdPersona = (int)drPersonas["id_persona"];
                    per.Nombre= (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];

                    personas.Add(per);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public Business.Entities.Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    per.IdPersona = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }

        public void Delete(Persona persona, BusinessEntity.States estado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE personas SET nombre = @nombre, apellido = @apellido, direccion = @direccion," +
                    "habilitado = @habilitado, email = @email, telefono = @telefono, fecha_nac = @fecha_nac " +
                    "WHERE id_persona=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.IdPersona;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                if (estado == BusinessEntity.States.Deleted)
                { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = false; }
                else
                { cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = true; }
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            if ((persona.State == BusinessEntity.States.Deleted) || (persona.State == BusinessEntity.States.Undeleted))
            {
                this.Delete(persona, persona.State);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            else
            {
                persona.State = BusinessEntity.States.Unmodified;
            }
        }
        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE personas SET nombre = @nombre, apellido = @apellido, direccion = @direccion," +
                    "habilitado = @habilitado, email = @email, telefono = @telefono, fecha_nac = @fecha_nac " +
                    "WHERE id_persona=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.IdPersona;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO personas(nombre, apellido, direccion, habilitado, email, telefono, fecha_nac)" +
                    "values(@nombre, @apellido, @direccion, @habilitado, @email, @telefono, @fecha_nac)" +
                    "select @@identity", SqlConn);
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                persona.IdPersona = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
