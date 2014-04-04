<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="cloudPOS._Default" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
    <div class="header">
        <ul class="nav nav-pills pull-right">
            <li class="active"><a href="Default.aspx">Home</a></li>          
            <li><a href="about.aspx" runat="server">About</a></li>
            <li><a href="contact.aspx" runat="server">Contact Us</a></li>
            <li><a href="login.aspx" runat="server">Sign In</a></li>
        </ul>
        <img  src="images/logo-small.png" class="text-muted"/>
    </div>
          
    <div class="row marketing">
        <div class="col-lg-6">
        <h4>Simple</h4>
	        <p>Easy to use with its user friendly web environment</p>
            <br/>
	        <h4>Cloud</h4>
	        <p>Powered by AppHarbor as it Platform as a Service (PaaS)</p>
        </div>
		<div class="col-lg-6">
	        <h4>Interactive</h4>
	        <p>Responsive web design compatible with your mobile devices.</p>
        </div>
    </div>
</asp:Content>