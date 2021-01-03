using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Boolean comprobarURL(String url)
        {
            int contador = 0; //Cuenta el número de puntos para comprobar si tiene subdominio
            foreach(char a in url)
            {
                if(a == '.')
                {
                    contador++;
                }
            }

            if(contador == 2)
            {
                return Regex.IsMatch(url, @"^(http|https)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)+\.(com|es|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk)/?([a-zA-Z0-9])");
            }
            else if(contador ==1)
            {
                return Regex.IsMatch(url, @"^(http|https)\://([a-zA-Z]*)+\.(com|es|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk)/?([a-zA-Z0-9])");
            }
            return false;
        }

        public string transformaHora(String hora)
        {
            if(String.IsNullOrEmpty(hora) || !hora.Contains(':') || hora.Length > 5 || hora.Length < 5)
            {
                return null;
            }

            string resultado = "";
            string am = " AM";
            string pm = " PM";

            int encontrar = hora.IndexOf(':');
            string h = hora.Remove(encontrar, hora.Length-2);
            string m = hora.Substring(encontrar+1);
            int horas = Int32.Parse(h);
            int minutos = Int32.Parse(m);

            if(horas > 23 || horas < 0 || minutos > 59 || minutos < 0)
            {
                return null;
            }

            if(horas > 12)
            {
                string hora_final = Convert.ToString(horas - 12);
                if(hora_final.Length < 2)
                {
                    hora_final = "0" + hora_final;
                }
                resultado = hora_final + ":" + m + pm;
            }
            else
            {
                resultado = h + ":" + m + am;
            }

            return resultado;
        }

        public int anosDesde(String fecha)
        {
            if (String.IsNullOrEmpty(fecha) || !fecha.Contains('/') || contarBarras(fecha) != 2)
            {
                return -1;
            }

            int resultado = -1;

            try
            {
                DateTime fecha1 = DateTime.Parse(fecha);
                DateTime fechaActual = DateTime.Now;
                if (fechaActual < fecha1)
                {
                    return -1;
                }
                resultado = fechaActual.Year - fecha1.Year;
            }
            catch (FormatException)
            {
                return -1;
            }

            return resultado;

        }

        public int contarBarras(String palabra)
        {
            int contador = 0;
            foreach(char a in palabra)
            {
                if (a.Equals('/'))
                {
                    contador++;
                }
            }
            return contador;
        }

        public Dictionary<string, int> anosMesesDiasDesde (String fecha1, String fecha2)
        {
            if(String.IsNullOrEmpty(fecha1) || String.IsNullOrEmpty(fecha2) || !fecha1.Contains('/') || contarBarras(fecha1) != 2
                || !fecha2.Contains('/') || contarBarras(fecha2) != 2)
            {
                return null;
            }

            Dictionary<string, int> resultado = new Dictionary<string, int>();

            try
            {
                DateTime fechaPrimera = DateTime.Parse(fecha1);
                DateTime fechaSegunda = DateTime.Parse(fecha2);
                if (fechaSegunda < fechaPrimera)
                {
                    return null;
                }

                int anos = fechaSegunda.Year - fechaPrimera.Year;
                int meses = fechaSegunda.Month - fechaPrimera.Month;
                int dias = fechaSegunda.Day - fechaPrimera.Day;

                if (meses < 0)
                {
                    anos -= 1;
                    meses += 12;
                }
                if (dias < 0)
                {
                    meses -= 1;
                    dias += DateTime.DaysInMonth(fechaSegunda.Year, fechaSegunda.Month);
                }

                resultado.Add("Años", anos);
                resultado.Add("Meses", meses);
                resultado.Add("Dias", dias);
            }
            catch (FormatException)
            {
                return null;
            }

            return resultado;
        }

        public int trieniosDesde(String fecha)
        {
            int anosFecha = anosDesde(fecha);
            if(anosFecha == -1)
            {
                return -1;
            }
            else
            {
                return anosFecha / 3;
            }
        }

        public int quinqueniosDesde(String fecha)
        {
            int anosFecha = anosDesde(fecha);
            if (anosFecha == -1)
            {
                return -1;
            }
            else
            {
                return anosFecha / 5;
            }
        }
    }
}

