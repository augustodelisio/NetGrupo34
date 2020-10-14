﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso:BusinessEntity
    {
        private int _IdCurso;
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        private int _AnioCalendario;
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        private int _Cupo;
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _IdComision;
        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value; }
        }

        private int _IdMateria;
        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }

        private bool _Habilitado;
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }
    }
}
