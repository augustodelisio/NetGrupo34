using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class DocenteCurso:BusinessEntity
    {
        private int _IDCurso;
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private int _IDDocente;
        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }

        private TiposCargos _Cargos;
        public TiposCargos Cargos
        {
            get { return _Cargos; }
            set { _Cargos = value; }
        }
    }

    public class TiposCargos
    {
    }
}
