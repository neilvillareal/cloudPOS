<%@ Page Language="vb" MasterPageFile="~/Dashboard.Master" AutoEventWireup="false" CodeBehind="dashboard.aspx.vb" Inherits="cloudPOS.dashboard" %>

<asp:Content runat="server" ID="DashContent" ContentPlaceHolderID="DashContent">
    <br /><br />
    <div class="container">
        <div class="col-md-8">
		    <div class="panel panel-warning">
			    <div class="panel-heading">
				    <h3 class="panel-title">Home</h3>
			    </div>
			    <div class="panel-body">
				    <h2>Welcome <strong><% Response.Write(Session("firstname").ToString.ToUpper + " " + Session("lastname").ToString.ToUpper)%></strong>!!</h2>
			    </div>
		    </div>
	    </div>

        <div class="col-md-4">
		    <div class="panel panel-primary">
			    <div class="panel-heading">
				    <h3 class="panel-title">Best Sellers</h3>
			    </div>
			    <div class="panel-body">
				
			    </div>
		    </div>
	    </div>
    </div>
</asp:Content>