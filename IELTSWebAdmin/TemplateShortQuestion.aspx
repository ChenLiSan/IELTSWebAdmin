<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateShortQuestion.aspx.cs" Inherits="IELTSWebAdmin.TemplateShortQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Question:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Number of Answer："></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Correct Answer:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

        </div>
    </form>
</body>
</html>
