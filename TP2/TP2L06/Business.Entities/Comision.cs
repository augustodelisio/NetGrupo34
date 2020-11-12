namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _IdComision;
        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value; }
        }

        private int _AnioEspecialidad;
        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
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
