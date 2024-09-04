<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageArticles.aspx.cs" Inherits="WebApplicationExam.ManageArticles" %>
<asp:TextBox ID="txtName" runat="server" Placeholder="Name"></asp:TextBox>
<asp:TextBox ID="txtDescription" runat="server" Placeholder="Description"></asp:TextBox>
<asp:TextBox ID="txtCategory" runat="server" Placeholder="Category"></asp:TextBox>
<asp:TextBox ID="txtGender" runat="server" Placeholder="Gender"></asp:TextBox>
<asp:TextBox ID="txtColor" runat="server" Placeholder="Color"></asp:TextBox>
<asp:TextBox ID="txtSize" runat="server" Placeholder="Size"></asp:TextBox>
<asp:TextBox ID="txtPrice" runat="server" Placeholder="Price"></asp:TextBox>
<asp:Button ID="btnAddArticle" runat="server" Text="Add Article" OnClick="btnAddArticle_Click" />
<asp:GridView ID="gvArticles" runat="server" AutoGenerateColumns="False" DataKeyNames="ArticleID" OnRowEditing="gvArticles_RowEditing" OnRowUpdating="gvArticles_RowUpdating" OnRowDeleting="gvArticles_RowDeleting">
    <Columns>
        <asp:BoundField DataField="ArticleID" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="Description" HeaderText="Description" />
        <asp:BoundField DataField="Category" HeaderText="Category" />
        <asp:BoundField DataField="Gender" HeaderText="Gender" />
        <asp:BoundField DataField="Color" HeaderText="Color" />
        <asp:BoundField DataField="Size" HeaderText="Size" />
        <asp:BoundField DataField="Price" HeaderText="Price" />
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
