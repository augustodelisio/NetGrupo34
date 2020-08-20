using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class TipoUsuario:BusinessEntity
    {
        private int _IdTipoUsuario;
        public int IdTipoUsuario
        {
            get { return _IdTipoUsuario; }
            set { _IdTipoUsuario = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private bool _Habilitado;
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }
    }
}
