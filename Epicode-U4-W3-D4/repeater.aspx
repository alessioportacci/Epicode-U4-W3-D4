<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repeater.aspx.cs" Inherits="Epicode_U4_W3_D4.repeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server" ItemType="Epicode_U4_W3_D4.Clienti">
                <ItemTemplate>
                    <%# Item.Nome %>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
