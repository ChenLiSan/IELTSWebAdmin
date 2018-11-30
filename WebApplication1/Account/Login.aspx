<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <%--<div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    
                </p>
            </section>
        </div>--%>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <!-- ko with: login -->
<hgroup class="title">
    <h1>Log in</h1>
</hgroup>
<div class="row-fluid">
    @*<section class="span7">
        <form>
            <fieldset class="form-horizontal">
                <legend>Use a local account to log in.</legend>
                <ul class="text-error" data-bind="foreach: errors">
                    <li data-bind="text: $data"></li>
                </ul>
                <div class="control-group">
                    <label for="UserName" class="control-label">User name</label>
                    <div class="controls">
                        <input type="text" name="UserName" data-bind="value: userName, hasFocus: true" />
                        <span class="text-error" data-bind="visible: userName.hasError, text: userName.errorMessage"></span>
                    </div>
                </div>
                <div class="control-group">
                    <label for="Password" class="control-label">Password</label>
                    <div class="controls">
                        <input type="password" name="Password" data-bind="value: password" />
                        <span class="text-error" data-bind="visible: password.hasError, text: password.errorMessage"></span>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <label class="checkbox">
                            <input type="checkbox" name="RememberMe" data-bind="checked: rememberMe" />
                            <label for="RememberMe">Remember me?</label>
                        </label>
                    </div>
                </div>
                <div class="form-actions no-color">
                    <button type="submit" class="btn" data-bind="click: login, disable: loggingIn">Log in</button>
                </div>
                <p><a href="#" data-bind="click: register">Register</a> if you don't have a local account.</p>
            </fieldset>
        </form>
    </section>*@
    <section class="span5">
        <h2>Log in using another service</h2>
        <div data-bind="visible: loadingExternalLogin">Loading...</div>
        <div data-bind="visible: !loadingExternalLogin()">
            <div class="message-info" data-bind="visible: !hasExternalLogin()">
                <p>
                    There are no external authentication services configured. See <a href="http://go.microsoft.com/fwlink/?LinkId=252166">this article</a>
                    for details on setting up this ASP.NET application to support logging in via external services.
                </p>
            </div>
            <form data-bind="visible: hasExternalLogin">
                <fieldset class="form-horizontal">
                    <legend>Use another service to log in.</legend>
                    <p data-bind="foreach: externalLoginProviders">
                        <button type="submit" class="btn" data-bind="text: name, attr: { title: 'Log in using your ' + name() + ' account' }, click: login"></button>
                    </p>
                </fieldset>
            </form>
        </div>
    </section>
</div>
<!-- /ko -->
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>
