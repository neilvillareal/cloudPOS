<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="cloudPOS.login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content="cloudPOS by Neil Salvador Sernande Villareal"/>
    <meta name="keywords" content="cloudPOS Cloud Based Point-of-Sale Web Application Powered by AppHarbor Neil Salvador Sernande Villareal Lientech Innovations">
    <meta name="author" content="Neil Salvador Sernande Villareal Lientech Innovations">
    <link rel="icon" href="favicon.ico" type="image/x-icon">    
    
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/navbar-fixed-top.css" rel="stylesheet">    
    <link href="css/signin.css" rel="stylesheet">

    <% 
        If Not Session("username") = Nothing Then
            Response.Redirect("dashboard.aspx")
        End If
    %>

    <title>cloudPOS - Sign In</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">        
        <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <script src="<%: ResolveUrl("~/Scripts/modernizr-2.5.3.js") %>"></script>
    </asp:PlaceHolder>
</head>
<body>
    <div class="container">
        <div class="header">
            <ul class="nav nav-pills pull-right">
                <li><a href="Default.aspx">Home</a></li>          
                <li><a id="A2" href="about.aspx" runat="server">About</a></li>
                <li><a id="A3" href="contact.aspx" runat="server">Contact Us</a></li>
                <li class="active"><a id="A4" href="login.aspx" runat="server">Sign In</a></li>
            </ul>
            <img  src="images/logo-small.png" class="text-muted"/>
        </div>

        <div align="center">
    	    <img src="images/logo.png" width="170px" height="200"/>
        </div>

        <h3 align="center" style="color: #0000cc;">Sign In <strong>cloudPOS</strong></h3>

        <form role="form" class="form-signin" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" TabIndex="1"></asp:TextBox>

            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TabIndex="2" TextMode="Password"></asp:TextBox>
            <br />
            
            <asp:Button ID="btnSignIn" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Sign In" TabIndex="3" />
            <br />
            <asp:Panel ID="pnErr" runat="server" CssClass="alert alert-danger" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="Invalid Username or Password"></asp:Label>
            </asp:Panel>
            <br />
            <a id="A1" href="#" runat="server" style="color: #cc0000;" tabindex="4">Forgot Password?</a>
            <br />
        </form>

        <footer>
            <div style="float: right;">
                <p align="right">
                    &copy; <%: DateTime.Now.Year %> - cloudPOS<br />
                    Neil Salvador Sernande Villareal
                </p>
            </div>
        </footer>
    </div>
</body>
</html>
