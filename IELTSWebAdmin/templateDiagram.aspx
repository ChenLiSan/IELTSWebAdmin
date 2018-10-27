<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="templateDiagram.aspx.cs" Inherits="IELTSWebAdmin.templateDiagram" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
        .auto-style2 {
            height: 151px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style2">
        <asp:Label ID="Label1" runat="server" Text="Insert Diagram:"></asp:Label>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Correct Answer:"></asp:Label>
        <div>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1"></asp:TextBox>
            
            <asp:Button ID="Button1" runat="server" Text="Button" CausesValidation="False" OnClick="Button1_Click"/>
 
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" ViewStateMode="Enabled"></asp:PlaceHolder>
 
        </div>
    </form>
</body>
</html>
