using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso:BusinessEntity
    {
        private int _IdDictado;
        public int IdDictado
        {
            get { return _IdDictado; }
            set { _IdDictado = value; }
        }

        private int _IdCurso;
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        private int _IdUsuario;
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        private TiposCargos _Cargos;
        public TiposCargos Cargos
        {
            get { return _Cargos; }
            set { _Cargos = value; }
        }
    }

    public enum TiposCargos
    {
        DocenteTeoria, JefeDeCatedra, DocentePractica
    }
}
