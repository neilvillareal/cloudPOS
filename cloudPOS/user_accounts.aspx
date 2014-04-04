<%@ Page Language="vb" MasterPageFile="~/Dashboard.Master" AutoEventWireup="false" CodeBehind="user_accounts.aspx.vb" Inherits="cloudPOS.user_accounts" %>

<asp:Content runat="server" ID="DashContent" ContentPlaceHolderID="DashContent">
    <br /><br />
    <div class="col-md-9">
        <div class="panel panel-warning">
			<div class="panel-heading">
				<h1 class="panel-title">User Accounts</h1>
			</div>
			<div class="panel-body">
                <asp:GridView ID="dgUsers" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="col-md-12" EnableSortingAndPagingCallbacks="True">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="White" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>

            </div>
        </div>
    </div>

    <div class="col-md-3">
        <div class="panel panel-warning">
			<div class="panel-heading">
				<h1 class="panel-title">Add New Account</h1>
			</div>
			<div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUsername" Cssclass="form-control" runat="server"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" Cssclass="form-control" runat="server"></asp:TextBox>
                
                <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                <asp:TextBox ID="txtCPass" Cssclass="form-control" runat="server"></asp:TextBox>
                
                <asp:Label ID="Label4" runat="server" Text="Lastname"></asp:Label>
                <asp:TextBox ID="txtLastname" Cssclass="form-control" runat="server"></asp:TextBox>
                
                <asp:Label ID="Label5" runat="server" Text="Firstname"></asp:Label>
                <asp:TextBox ID="txtFirstname" Cssclass="form-control" runat="server"></asp:TextBox>
                
                <asp:Label ID="Label6" runat="server" Text="Middlename"></asp:Label>
                <asp:TextBox ID="txtMiddlename" Cssclass="form-control" runat="server"></asp:TextBox>

                <asp:Label ID="Label7" runat="server" Text="User Type"></asp:Label>
                <asp:DropDownList ID="cboUtype" Cssclass="form-control" runat="server"></asp:DropDownList>
                <br /><br />
                <asp:Button ID="btnSubmit" Cssclass="btn btn-lg btn-primary btn-block" runat="server" Text="Add User" />
                <br /><br />
                <asp:Panel ID="pnErr" runat="server" CssClass="alert alert-danger" Visible="False">
                    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <asp:Panel ID="pnSucc" runat="server" CssClass="alert alert-success"  Visible="False">
                    <asp:Label ID="lblSucc" runat="server" Text="Successfully add new User."></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>

</asp:Content>