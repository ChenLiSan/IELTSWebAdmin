<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="IELTSWebAdmin.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
     <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Sign Up Form</title>

    <!-- Font Icon -->
    <link rel="stylesheet" href="fonts/material-icon/css/material-design-iconic-font.min.css" />

    <!-- Main css -->
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    
        <div class="main">

        <!-- Sign up form -->
        <section class="signup">
            <div class="container">
                <div class="signup-content">
                    <div class="signup-form">
                        <h2 class="form-title">Sign up</h2>
                        
                            <form id="form1" runat="server">
                            <div class="form-group">
                                <%--<asp:Label ID="lblName" runat="server" Text="Username: " class="zmdi zmdi-account material-icons-name" placeholder="Your Name"></asp:Label>--%>
                                <asp:label runat="server" for="name"><i class="zmdi zmdi-account material-icons-name"></i></asp:label>
                                <input runat="server" type="text" id="txtUsername" placeholder="Your Name"/>
                            </div>
                            <div class="form-group">
                                <asp:label runat="server" for="email"><i class="zmdi zmdi-email"></i></asp:label>
                                <input runat="server" type="text" id="txtEmail" placeholder="Your Email" />
                            </div>
                            <div class="form-group">
                                <asp:label runat="server" for="pass"><i class="zmdi zmdi-lock"></i></asp:label>
                                <input runat="server" type="password" id="txtPass" placeholder="Password"/>
                            </div>
                            <div class="form-group">
                                <asp:label runat="server" for="re-pass"><i class="zmdi zmdi-lock-outline"></i></asp:label>
                                <input runat="server" type="password" id="txtConPass" placeholder="Repeat your password" />
                            </div>
                            <%--<div class="form-group">
                                <input type="checkbox" name="agree-term" id="agree-term" class="agree-term" />
                                <label for="agree-term" class="label-agree-term"><span><span></span></span>I agree all statements in  <a href="#" class="term-service">Terms of service</a></label>
                            </div>--%>
                            <div class="form-group form-button">
                               <%-- <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click1" Text="Register" />--%>
                                <asp:Button runat="server" Text="Register" name="signup" id="btnSubmit" class="form-submit" value="Register" OnClick="signup_Click"/>
                            </div>
                        </form>
                    </div>
                    <div class="signup-image">
                        <figure><img src="Image/signup-image.jpg" alt="sing up image" /></figure>
                        <a href="Login.aspx" class="signup-image-link">I am already register</a>
                    </div>
                </div>
            </div>
         
        </section>
      
        </div>
</body>
</html>
