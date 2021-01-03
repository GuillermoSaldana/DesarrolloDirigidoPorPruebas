<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EntornoWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            color: #0033CC;
            text-decoration: underline;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 59px;
        }
        .auto-style4 {
            height: 59px;
            text-align: right;
            width: 607px;
        }
        .auto-style5 {
            text-align: right;
            width: 607px;
        }
        .auto-style6 {
            width: 607px;
        }
        .auto-style9 {
            height: 58px;
            text-align: right;
            width: 607px;
        }
        .auto-style10 {
            height: 58px;
        }
        .auto-style11 {
            text-align: right;
            width: 607px;
            height: 83px;
        }
        .auto-style12 {
            height: 83px;
        }
        .auto-style13 {
            height: 82px;
            text-align: right;
            width: 607px;
        }
        .auto-style14 {
            height: 82px;
        }
        .auto-style15 {
            height: 76px;
            text-align: right;
            width: 607px;
        }
        .auto-style16 {
            height: 76px;
        }
        .auto-style17 {
            width: 239px;
        }
        .auto-style18 {
            height: 59px;
            width: 239px;
        }
        .auto-style19 {
            height: 58px;
            width: 239px;
        }
        .auto-style20 {
            height: 83px;
            width: 239px;
        }
        .auto-style21 {
            height: 82px;
            width: 239px;
        }
        .auto-style22 {
            height: 76px;
            width: 239px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style2">
                <caption class="auto-style1">
                    <strong>Rellena los cuadros con los datos que se indiquen</strong></caption>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Introduce un correo elecctronico:</td>
                    <td class="auto-style18">
                        <asp:TextBox ID="TextBoxCorreo" runat="server" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="LblErrorCorreo" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:Label ID="LabelCorreo" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Introduce tu NIF:</td>
                    <td class="auto-style18">
                        <asp:TextBox ID="TextBoxNIF" runat="server" Height="26px" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="LblErrorNIF" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:Label ID="LabelNIF" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Introduce un codigo postal:</td>
                    <td class="auto-style18">
                        <asp:TextBox ID="TextBoxCP" runat="server" Height="31px" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="LblErrorCP" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:Label ID="LabelCP" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Introduce una contratseña (Debe tener al menos, más de 11 caracteres, un a mayuscula, una minuscula, un número o un signo especial (- , _ , +, *, #)):</td>
                    <td class="auto-style19">
                        <asp:TextBox ID="TextBoxContrasena2" runat="server" Height="29px" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="LblErrorContrasena" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:Label ID="LabelContrasena2" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">Introduce una hora para ver su fromato en AM o PM (Las horas y los minutos se representan con dos dígitos, separados por dos puntos sin espacios (Ej. 02:13):</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="TextBoxAMPM" runat="server" Height="25px" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="LblErrorAMPM" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:Label ID="LabelAMPM" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">Introduce dos fecha (la primera anterior a la segunda) para comprobar cuantos años dias y meses han pasado. (Debe tener el formato dia/mes/año):</td>
                    <td class="auto-style21">
                        <asp:TextBox ID="TextBoxAnos1" runat="server" Height="30px" Width="223px"></asp:TextBox>
                        <asp:TextBox ID="TextBoxAnos2" runat="server" Height="26px" Width="222px"></asp:TextBox>
                    </td>
                    <td class="auto-style14">
                        <asp:Label ID="LblErrorAnos" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:Label ID="LabelAnos" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">Introduce una fecha con el mismo formato que en el paso anterior para comrpobar cuantos trienios han pasado entre la fecha elegida y la actual:</td>
                    <td class="auto-style22">
                        <asp:TextBox ID="TextBoxTrienios" runat="server" Height="31px" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        <asp:Label ID="LblErrorTrienios" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:Label ID="LabelTrienios" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style17">
                        <asp:Button ID="ButtonAceptar" runat="server" OnClick="ButtonAceptar_Click" Text="Aceptar" Width="225px" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Borrar datos" Width="195px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
