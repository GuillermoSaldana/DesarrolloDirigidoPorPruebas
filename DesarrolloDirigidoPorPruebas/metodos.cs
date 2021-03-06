﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace DesarrolloDirigidoPorPruebas
{
    public class Metodos
    {
        public Boolean comprobarCorreoElectronico(String correo)
        {
            return Regex.IsMatch(correo, @"\A[a-zA-Z0-9\-_]+@[a-zA-Z0-9\-]+\.[a-zA-Z]{2,3}\Z");
        }

        public Boolean comprobarNIF(String NIF)
        {
            int total;
            List<char> control = new List<char>() { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'I', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };
            Boolean sol1 = Regex.IsMatch(NIF, @"\A[0-9]{8}[A-Z]{1}\Z");
            Boolean sol2 = Regex.IsMatch(NIF, @"\A[KLMXYZ]{1}[0-9]{7}[A-Z]{1}\Z");
            if (sol1 == true)
            {
                total = Convert.ToInt32(NIF.Substring(0, 8));
            }
            else if (sol2 == true)
            {
                total = Convert.ToInt32(NIF.Substring(1, 7));
            }
            else
            {
                return false;
            }
            int numControl = total % 23;
            return control[numControl] == NIF[8];
        }

        public Boolean comprobarNIE(String NIE)
        {
            List<char> control = new List<char>() { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'I', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };
            Boolean sol = Regex.IsMatch(NIE, @"\A[MXYZ]{1}[0-9]{7}[A-Z]{1}\Z");
            if (sol == true)
            {
                int total = Convert.ToInt32(NIE.Substring(1, 7));
                int numControl = total % 23;
                return control[numControl] == NIE[8];
            }
            return false;

        }

        public Boolean comprobarCIF(String CIF)
        {
            List<char> control = new List<char>() { 'J', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            Boolean sol = Regex.IsMatch(CIF, @"\A[ABCDEFGHKLMNPQSX]{1}[0-9]{7}[A-Z0-9]{1}\Z");
            if (sol == true)
            {
                var rgx = new Regex(@"^[0-9]{2}$");
                int totalPar = 0;
                int totalImpar = 0;
                for (int i = 1; i < 8; i += 2)
                {
                    if (i % 2 != 0)
                    {
                        totalPar += Convert.ToInt32(Char.GetNumericValue(CIF[i]));
                    }
                    else
                    {
                        int num = Convert.ToInt32(Char.GetNumericValue(CIF[i])) * 2;
                        if (rgx.IsMatch(Convert.ToString(num)))
                        {
                            int decenas = num / 10;
                            int unidades = num % 10;
                            num = decenas + unidades;
                        }
                        totalImpar += num;
                    }
                }
                int totalFinal = totalPar + totalImpar;
                return calcularCoincidenciaNumControl(control, totalFinal, CIF);
            }
            else
            {
                return false;
            }
        }

        private Boolean calcularCoincidenciaNumControl(List<char> control, int totalFinal, String CIF)
        {
            totalFinal = totalFinal % 10;
            int numControl = 10 - totalFinal;
            if (CIF[0] == 'K' || CIF[0] == 'P' || CIF[0] == 'Q' || CIF[0] == 'S')
            {
                return control[numControl] == CIF[8];
            }
            else
            {
                return numControl == Convert.ToInt32(Char.GetNumericValue(CIF[8]));
            }
        }

        public Boolean comprobarCodigoPostal(String CodigoPostal)
        {
            return Regex.IsMatch(CodigoPostal, @"\A(^[1-4]{1}[0-9]{4}$)|(^[0]{1}[1-9]{1}[0-9]{3}$)|(^[5]{1}[0-2]{1}[0-9]{3}$)\Z");
        }

        public Boolean comprobarIBAN(String IBAN)
        {
            Boolean sol = Regex.IsMatch(IBAN, @"\AES[0-9]{2}\s[0-9]{4}\s[0-9]{4}\s[0-9]{2}\s[0-9]{10}\Z");
            if (sol == true)
            {
                String IBANsinespacio = IBAN.Replace(" ", "");
                String num = IBANsinespacio.Substring(4, 20);
                num += "142800";
                decimal resto = Convert.ToDecimal(num) % 97;
                decimal final = 98 - resto;
                return final == Convert.ToDecimal(IBANsinespacio.Substring(2, 2));
            }
            return false;
        }

        public Boolean comprobarIPv4(String IPv4)
        {
            Boolean sol = Regex.IsMatch(IPv4, @"\A[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\Z");
            String[] partes = IPv4.Split('.');
            if (sol == true)
            {
                foreach (String parte in partes)
                {
                    if (Convert.ToInt32(parte) > 255)
                    {
                        return false;
                    }
                }
                if (entreClaseAyB(partes) || entreClaseByC(partes) || fueraDeClaseAyC(partes)) { 
                    return false;
                }
                return true;
            }
            return false;

        }

        private Boolean entreClaseAyB(String[] partes)
        {
            return Convert.ToInt32(partes[0]) == 127 && Convert.ToInt32(partes[1]) != 0 && Convert.ToInt32(partes[2]) != 0 && Convert.ToInt32(partes[3]) != 0;
        }

        private Boolean entreClaseByC(String[] partes)
        {
            return Convert.ToInt32(partes[0]) == 191 && Convert.ToInt32(partes[1]) == 255 && Convert.ToInt32(partes[2]) != 0 && Convert.ToInt32(partes[3]) != 0;
        }

        private Boolean fueraDeClaseAyC(String[] partes)
        {
            return (Convert.ToInt32(partes[0]) == 223 && Convert.ToInt32(partes[1]) == 255 && Convert.ToInt32(partes[2]) == 255 && Convert.ToInt32(partes[3]) != 0) || (Convert.ToInt32(partes[0]) > 233 || Convert.ToInt32(partes[0]) < 1);
        }

        public Boolean comprobarContrasena1(String contrasena)
        {
            List<char> lista = contrasena.ToList<char>();

            if (string.IsNullOrEmpty(contrasena))
            {
                return false;
            }

            if (contrasena.Length > 8 && contieneMayuscula(lista) && contieneMinuscula(lista)
                && contieneNumeros(lista))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
            List<char> listaEspecial = new List<char>() { '-', '_', '+', '*', '#' };

            foreach (char a in listaEspecial)
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
            foreach (char a in url)
            {
                if (a == '.')
                {
                    contador++;
                }
            }
            if (contador == 2)
            {
                return Regex.IsMatch(url, @"^(http|https)://[a-zA-Z0-9]+\.[a-zA-Z]+\.(com|es|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk)/?([a-zA-Z0-9]*)$");
            }
            else if (contador == 1)
            {
                return Regex.IsMatch(url, @"^(http|https)://[a-zA-Z]+\.(com|es|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk)/?([a-zA-Z0-9]*)$");
            }
            return false;
        }

        public string transformaHora(String hora)
        {
            if (String.IsNullOrEmpty(hora) || !hora.Contains(':') || hora.Length > 5 || hora.Length < 5)
            {
                return null;
            }

            string resultado = "";
            string am = " AM";
            string pm = " PM";

            int encontrar = hora.IndexOf(':');
            string h = hora.Remove(encontrar, hora.Length - 2);
            string m = hora.Substring(encontrar + 1);
            int horas = Int32.Parse(h);
            int minutos = Int32.Parse(m);

            if (horas > 23 || horas < 0 || minutos > 59 || minutos < 0)
            {
                return null;
            }

            if (horas > 12)
            {
                string hora_final = Convert.ToString(horas - 12);
                if (hora_final.Length < 2)
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
            foreach (char a in palabra)
            {
                if (a.Equals('/'))
                {
                    contador++;
                }
            }
            return contador;
        }

        public Dictionary<string, int> anosMesesDiasDesde(String fecha1, String fecha2)
        {
            if (String.IsNullOrEmpty(fecha1) || String.IsNullOrEmpty(fecha2) || !fecha1.Contains('/') || contarBarras(fecha1) != 2
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
            if (anosFecha == -1)
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


