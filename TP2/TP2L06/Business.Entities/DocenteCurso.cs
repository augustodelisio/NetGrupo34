namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
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

        private int _Cargos;
        public int Cargos
        {
            get { return _Cargos; }
            set { _Cargos = value; }
        }
    }
}
