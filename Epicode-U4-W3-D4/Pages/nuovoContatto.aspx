<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nuovoContatto.aspx.cs" Inherits="Epicode_U4_W3_D4.Pages.nuovoContatto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <p> Nome </p>
            <asp:TextBox ID="Nome" runat="server"></asp:TextBox>

            <p> Cognome </p>
            <asp:TextBox ID="Cognome" runat="server"></asp:TextBox>

            <p> Indirizzo </p>
            <asp:TextBox ID="Indirizzo" runat="server"></asp:TextBox>

            <p> Numero </p>
            <asp:TextBox ID="Numero" runat="server"></asp:TextBox>
                        
            <p> Email </p>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>

            <p> Foto </p>
            <asp:FileUpload ID="FileUpload" runat="server" />

            
            <asp:Button ID="Aggiungi" runat="server" Text="Aggiungi Contatto" OnClick="Aggiungi_Click" />


        </div>
    </form>
</body>
</html>
