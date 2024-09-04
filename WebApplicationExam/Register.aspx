<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplicationExam.Register" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inscription</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Inscription</h2>
            <div>
                <asp:TextBox ID="txtFirstName" runat="server" Placeholder="Prénom"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtLastName" runat="server" Placeholder="Nom"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtDateOfBirth" runat="server" Placeholder="Date de Naissance"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtLogin" runat="server" Placeholder="Login"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Mot de passe"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnRegister" runat="server" Text="S'enregistrer" OnClick="btnRegister_Click" />
            </div>
        </div>
    </form>
</body>
</html>