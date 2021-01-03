using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace DesarrolloDirigidoPorPruebas
{
    public class Metodos
    {
        List<string> listaEspecial = new List<string>();
        
        public Boolean comprobarCorreoElectronico(String correo)
        {
            return Regex.IsMatch(correo, @"\A[a-zA-Z0-9\-_]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,3}\Z");
        }

        public Boolean comprobarNIF(String NIF)
        {
            List<char> control = new List<char>() { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'I', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};
            Boolean sol1 = Regex.IsMatch(NIF, @"\A[0-9]{8}[A-Z]{1}\Z");
            Boolean sol2 = Regex.IsMatch(NIF, @"\A[KLMXYZ]{1}[0-9]{7}[A-Z]{1}\Z");
            if(sol1 == true){
                int total = 0;
                for (int i = 0; i < 8; i++)
                {
                    total += Convert.ToInt32(Char.GetNumericValue(NIF[i]));
                }
                int numControl = total % 23;
                return control[numControl] == NIF[8];
            }else if(sol2 == true)
            {
                int total = 0;
                for (int i = 1; i < 8; i++)
                {
                    total += Convert.ToInt32(Char.GetNumericValue(NIF[i]));
                }
                int numControl = total % 23;
                return control[numControl] == NIF[8];
            }
            else
            {
                return false;
            }
        }

        public Boolean comprobarNIE(String NIE)
        {
            List<char> control = new List<char>() { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'I', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };
            Boolean sol = Regex.IsMatch(NIE, @"\A[MXYZ]{1}[0-9]{7}[A-Z]{1}\Z");
            int total = 0;
            if(sol == true){
                for (int i = 1; i < 8; i++)
                {
                    total += Convert.ToInt32(Char.GetNumericValue(NIE[i]));
                }
                int numControl = total % 23;
                return control[numControl] == NIE[8];
            }
            return false;

        }

        public Boolean comprobarCIF(String CIF)
        {
            List<char> control = new List<char>() { 'J', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            Boolean sol = Regex.IsMatch(CIF, @"\A[ABCDEFGHKLMNPQSX]{1}[0-9]{7}[A-Z0-9]{1}\Z");
            if(sol == true)
            {
                var rgx = new Regex(@"^[0-9]{2}$");
                int totalPar = 0;
                int totalImpar = 0;
                for (int i = 2; i < 8; i+=2)
                {
                    totalPar += Convert.ToInt32(Char.GetNumericValue(CIF[i]));
                }
                int num;
                for (int i = 1; i < 8; i+=2)
                {
                    num = Convert.ToInt32(Char.GetNumericValue(CIF[i])) * 2;
                    if (rgx.IsMatch(Convert.ToString(num))) 
                    {
                        int decenas = num / 10;
                        int unidades = num % 10;
                        num = decenas + unidades;
                    }
                    totalImpar += num;
                }
                int totalFinal = totalPar + totalImpar;
                totalFinal = totalFinal % 10;
                int numControl = 10 - totalFinal;
                if (CIF[0]=='K' || CIF[0] == 'P' || CIF[0] == 'Q' || CIF[0] == 'S')
                {
                    return control[numControl] == CIF[8];
                }
                else
                {
                    return numControl == Convert.ToInt32(Char.GetNumericValue(CIF[8]));
                }
            }
            return false;
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
                if(Convert.ToInt32(partes[0])==127 && Convert.ToInt32(partes[1]) != 0 && Convert.ToInt32(partes[2]) != 0 && Convert.ToInt32(partes[3]) != 0 ){
                    return false;
                }
                if (Convert.ToInt32(partes[0]) == 191 && Convert.ToInt32(partes[1]) == 255 && Convert.ToInt32(partes[2]) != 0 && Convert.ToInt32(partes[3]) != 0)
                {
                    return false;
                }
                if (Convert.ToInt32(partes[0]) == 223 && Convert.ToInt32(partes[1]) == 255 && Convert.ToInt32(partes[2]) == 255 && Convert.ToInt32(partes[3]) != 0)
                {
                    return false;
                }
                if (Convert.ToInt32(partes[0]) > 233 || Convert.ToInt32(partes[0]) < 1)
                {
                    return false;
                }
                return true;
            }
            return false;

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

