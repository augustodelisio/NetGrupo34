using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloTipoUsuario:BusinessEntity
    {
        private int _IdModuloTU;
        public int IdModuloTU
        {
            get { return _IdModuloTU; }
            set { _IdModuloTU = value; }
        }

        private bool _PermiteAlta;
        public bool PermiteAlta
        {
            get { return _PermiteAlta; }
            set { _PermiteAlta = value; }
        }

        private bool _PermiteBaja;
        public bool PermiteBaja
        {
            get { return _PermiteBaja; }
            set { _PermiteBaja = value; }
        }

        private bool _PermiteModificacion;
        public bool PermiteModificacion
        {
            get { return _PermiteModificacion; }
            set { _PermiteModificacion = value; }
        }

        private bool _PermiteConsulta;
        public bool PermiteConsulta
        {
            get { return _PermiteConsulta; }
            set { _PermiteConsulta = value; }
        }

        private int _IdTipoUsuario;
        public int IdTipoUsuario
        {
            get { return _IdTipoUsuario; }
            set { _IdTipoUsuario = value; }
        }

        private int _IdModulo;
        public int IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }

    }
}
