using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDirigidoPorPruebas
{
    public class Metodos
    {
        List<string> listaEspecial = new List<string>();

        public Boolean comprobarContrasena2(String contrasena)
        {
            List<char> lista = contrasena.ToList<char>();

            if (string.IsNullOrEmpty(contrasena))
            {
                return false;
            }

            if (contrasena.Length > 10 && contieneMayuscula(lista) && contieneMinuscula(lista) 
                && contieneNumeros(lista) && contieneCaracterEspecial(contrasena))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean contieneMayuscula(List<char> contrasena)
        {
            foreach (char a in contrasena)
            {
                if (char.IsUpper(a))
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean contieneMinuscula(List<char> contrasena)
        {
            foreach (char a in contrasena)
            {
                if (char.IsLower(a))
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean contieneNumeros(List<char> contrasena)
        {
            foreach (char a in contrasena)
            {
                if (char.IsDigit(a))
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean contieneCaracterEspecial(string contrasena)
        {
            listaEspecial.Add("-");
            listaEspecial.Add("_");
            listaEspecial.Add("+");
            listaEspecial.Add("*");
            listaEspecial.Add("#");

            foreach (String a in listaEspecial)
            {
                if (contrasena.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

