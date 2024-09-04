<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplicationExam.Home" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Bienvenue sur la page d'accueil</h2>
            <!-- Bouton de déconnexion -->
            <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click">Déconnexion</asp:LinkButton>
        </div>
    </form>
</body>
</html>
