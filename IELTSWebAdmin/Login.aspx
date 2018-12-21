<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IELTSWebAdmin.Login" %>

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
    
       <section class="sign-in">
            <div class="container">
                <div class="signin-content">
                    <div class="signin-image">
                        <figure><img src="Image/signin-image.jpg" alt="sing up image" /></figure>
                        <a href="Registration.aspx" class="signup-image-link">Create an account</a>
                    </div>
                    <div class="signin-form">
                    <form id="form1" runat="server">

                        <h2 class="form-title">Login</h2>
                       
                            <div class="form-group">
                                <asp:label runat="server" for="your_name"><i class="zmdi zmdi-account material-icons-name"></i></asp:label>
                                <input runat="server" type="text" name="your_name" id="txtUsername" placeholder="Your Name"/>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300"></asp:Label>

                            &nbsp;</div>
                            <div class="form-group">
                                <asp:label runat="server" for="your_pass"><i class="zmdi zmdi-lock"></i></asp:label>
                                <input runat="server" type="password" name="your_pass" id="txtPass" placeholder="Password"/>
                            </div>
                        <%--  <div class="form-group">
                                <input type="checkbox" name="remember-me" id="remember-me" class="agree-term" />
                                <label for="remember-me" class="label-agree-term"><span><span></span></span>Remember me</label>
                            </div>--%>
                        <div class="form-group form-button">
                            <asp:Button runat="server" text="Login" type="submit" name="signin" id="signin" class="form-submit" value="Log in" OnClick="signin_Click" />
                        </div>
                    </form>
                        <%-- <div class="social-login">
                            <span class="social-label">Or login with</span>
                            <ul class="socials">
                                <li><a href="#"><i class="display-flex-center zmdi zmdi-facebook"></i></a></li>
                                <li><a href="#"><i class="display-flex-center zmdi zmdi-twitter"></i></a></li>
                                <li><a href="#"><i class="display-flex-center zmdi zmdi-google"></i></a></li>
                            </ul>
                        </div>--%>
                    </div>
                </div>
            </div>

       </section>

</body>
</html>
