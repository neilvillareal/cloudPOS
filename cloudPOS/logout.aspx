<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="logout.aspx.vb" Inherits="cloudPOS.logout" %>

<html>
    <head>
        <% 
            Session.Clear()
            Response.Redirect("Default.aspx")
        %>
    </head>
    <body>

    </body>
</html>