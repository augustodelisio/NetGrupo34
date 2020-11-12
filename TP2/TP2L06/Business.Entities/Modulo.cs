namespace Business.Entities
{
    public class Modulo
    {
        private int _IdModulo;
        public int IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
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
