<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WebApplicationExam.ManageUsers" %>
<asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" OnRowDeleting="gvUsers_RowDeleting" OnRowEditing="gvUsers_RowEditing">
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
        <asp:BoundField DataField="Login" HeaderText="Login" ReadOnly="True" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
