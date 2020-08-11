﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia:BusinessEntity
    {
        private int _IdMateria;
        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _HsSemanales;
        public int HsSemanales
        {
            get { return _HsSemanales; }
            set { _HsSemanales = value; }
        }

        private int _HsTotales;
        public int HsTotales
        {
            get { return _HsTotales; }
            set { _HsTotales = value; }
        }

        private bool _Habilitado;
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        private int _IdPlan;
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
    }
}
