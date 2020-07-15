﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        private UsuarioAdapter _UsuarioData;
        public UsuarioAdapter UsuarioData 
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; } 
        }  

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();               
        }
        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }
        public void Save(Usuario usu)
        {
            UsuarioData.Save(usu);
        }
    }
}
