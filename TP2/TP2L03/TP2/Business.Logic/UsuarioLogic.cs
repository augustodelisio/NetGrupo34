using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        public UsuarioLogic()
        {
            Data.Database.UsuarioAdapter UsuarioData 
        }
        public List<Usuario> GetAll()
        {
            return new List<Usuario>();//Reemplazar (punto 7)
        }

        public Usuario GetOne(int id)
        {
            return new Usuario();//Reemplazar (punto 8)
        }

        public void Delete(int id)
        {

        }
        public void Save(Usuario usu)
        {

        }
    }
}
