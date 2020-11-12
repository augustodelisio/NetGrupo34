namespace Business.Entities
{
    public class AlumnoCurso : BusinessEntity
    {
        private int _IdInscripcion;
        public int IdInscripcion
        {
            get { return _IdInscripcion; }
            set { _IdInscripcion = value; }
        }

        private string _Condicion;
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        private float _Nota;
        public float Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
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
    }
}
