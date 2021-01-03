using DesarrolloDirigidoPorPruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntornoWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Metodos m = new Metodos();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (m.comprobarCorreoElectronico(TextBoxCorreo.Text))
            {
                LblErrorCorreo.Text = "";
                LabelCorreo.Text = "El correo tiene un formato correcto";
            }
            else
            {
                LabelCorreo.Text = "";
                LblErrorCorreo.Text = "El correo no presenta un formato correcto";
            }

            if (m.comprobarNIF(TextBoxNIF.Text))
            {
                LblErrorNIF.Text = "";
                LabelNIF.Text = "El NIF es correcto";
            }
            else
            {
                LabelNIF.Text = "";
                LblErrorNIF.Text = "El NIF no es correcto";
            }

            if (m.comprobarCodigoPostal(TextBoxCP.Text))
            {
                LblErrorCP.Text = "";
                LabelCP.Text = "El codigo postal es correcto";
            }
            else
            {
                LabelCP.Text = "";
                LblErrorCP.Text = "El codigo postal no es correcto";
            }

            if(m.comprobarContrasena2(TextBoxContrasena2.Text) == true)
            {
                LblErrorContrasena.Text = "";
                LabelContrasena2.Text = "La contraseña es correcta";
            }
            else
            {
                LabelContrasena2.Text = "";
                LblErrorContrasena.Text = "La contraseña no cumple las condiciones";
            }

            if(m.transformaHora(TextBoxAMPM.Text) != null)
            {
                LblErrorAMPM.Text = "";
                LabelAMPM.Text = m.transformaHora(TextBoxAMPM.Text);
            }
            else
            {
                LabelAMPM.Text = "";
                LblErrorAMPM.Text = "Hay algún error con la hora, puede que no cumpla los requisitos" +
                    "o que sea una hora que no existe";
            }

            if(m.anosMesesDiasDesde(TextBoxAnos1.Text,TextBoxAnos2.Text) != null)
            {
                LblErrorAnos.Text = "";
                Dictionary<string, int> diccionario = m.anosMesesDiasDesde(TextBoxAnos1.Text, TextBoxAnos2.Text);
                LabelAnos.Text = diccionario["Años"].ToString() + "Años, " + diccionario["Meses"].ToString() + "Meses y " + diccionario["Dias"].ToString() + "Dias";
            }
            else
            {
                LabelAnos.Text = "";
                LblErrorAnos.Text = "Hay algún error con la fecha, puede que no cumpla los requisitos," +
                    "que la fecha no exista o que la fecha primera sea mayor que la segunda";
            }

            if(m.trieniosDesde(TextBoxTrienios.Text) != -1)
            {
                LblErrorTrienios.Text = "";
                LabelTrienios.Text = m.trieniosDesde(TextBoxTrienios.Text) + " Trienios";
            }
            else
            {
                LabelTrienios.Text = "";
                LblErrorTrienios.Text = "Hay algún error con la fecha, puede que no cumpla los requisitos," +
                    "que la fecha no exista o que la fecha sea mayor que la actual";
            }
           
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm1.aspx");
        }
    }
}