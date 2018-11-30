<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="googleLogin.aspx.cs" Inherits="IELTSWebAdmin.googleLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnLogin" Text="Google Login" runat="server" />
             <hr />

<section id ="socialLoginForm">
    @html.Partial("_ExtternalLoginsListPartial", new External)
</section>
        </div>
    </form>
</body>
</html>
