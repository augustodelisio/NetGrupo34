using System;
using System.Text.RegularExpressions;

namespace Util
{
    public class Validaciones
    {
        public static bool EsMailCorrecto(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool campoLleno(string campo)
        {
            if (String.IsNullOrEmpty(campo))
                return false;
            else return true;
        }

        public static bool clavesIguales(string clave1, string clave2)
        {
            if (String.Equals(clave1, clave2, StringComparison.Ordinal))
                return true;
            else return false;
        }

        public static bool minAlcanzado(string campo, int min)
        {
            if (campo.Length >= min)
                return true;
            else return false;
        }

        public static bool validaNota(float nota)
        {
            if (nota >= 0 && nota <= 10)
                return true;
            else return false;
        }

        public static bool maxAlcanzado(string campo, int max)
        {
            if (campo.Length <= max)
                return true;
            else return false;
        }
    }
}
