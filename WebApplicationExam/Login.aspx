<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplicationExam.Login" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page de Connexion</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Connexion</h2>
            <div>
                <asp:TextBox ID="txtLogin" runat="server" Placeholder="Login"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Mot de passe"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Connexion" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
