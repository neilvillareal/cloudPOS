﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="about.aspx.vb" Inherits="cloudPOS.about" %>

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
    
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/navbar-fixed-top.css" rel="stylesheet">    
    <link href="css/jumbotron-narrow.css" rel="stylesheet">    
    <link href="css/carousel.css" rel="stylesheet">
    
    <title>cloudPOS - About</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">        
        <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <script src="<%: ResolveUrl("~/Scripts/modernizr-2.5.3.js") %>"></script>
    </asp:PlaceHolder>
</head>
<body>
    <div class="container">
        <form runat="server">
            <div class="header">
                <ul class="nav nav-pills pull-right">
                    <li><a href="Default.aspx">Home</a></li>          
                    <li class="active"><a id="A1" href="about.aspx" runat="server">About</a></li>
                    <li><a id="A2" href="contact.aspx" runat="server">Contact Us</a></li>
                    <li><a id="A3" href="login.aspx" runat="server">Sign In</a></li>
                </ul>
                <img  src="images/logo-small.png" class="text-muted"/>
            </div>
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

    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>    
</body>
</html>