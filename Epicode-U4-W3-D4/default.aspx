<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="default.aspx.cs" Inherits="Epicode_U4_W3_D4._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Nuovo contatto--->
            <asp:Button ID="Nuovo" runat="server" Text="Nuovo contatto" OnClick="Nuovo_Click" />
            <br />

            <!-- Repeater -->
            <asp:Repeater ID="RepeaterContatti" runat="server" ItemType="Epicode_U4_W3_D4.Contatti">
                <ItemTemplate>

                    <img src="Content/img/<%# Item.Foto%>" height="50"/>
                    <p><%# Item.Nome %> <%# Item.Cognome %> </p>

                    <ul>
                        <li> <%# Item.Email %></li>
                        <li>  <%# Item.Numero %></li>
                    </ul>

                    <asp:Button ID="Modifica" runat="server" Text="Modifica" CommandArgument="<%# Item.ID %>" OnClick="Modifica_Click"/>
                    <asp:Button ID="Elimina" runat="server" Text="Elimina" CommandArgument="<%# Item.ID %>" OnClick="Elimina_Click" />

                    <br />
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
