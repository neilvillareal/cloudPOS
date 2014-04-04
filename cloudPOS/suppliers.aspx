<%@ Page Language="vb" MasterPageFile="~/Dashboard.Master" AutoEventWireup="false" CodeBehind="suppliers.aspx.vb" Inherits="cloudPOS.suppliers" %>

<asp:Content runat="server" ID="DashContent" ContentPlaceHolderID="DashContent">
    <br /><br />
    <div class="col-md-9">
        <div class="panel panel-success">
			<div class="panel-heading">
				<h3 class="panel-title">Suppliers</h3>
			</div>
			<div class="panel-body">
                <asp:GridView ID="dgSuppliers" CssClass ="col-md-12" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
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
        <div class="panel panel-success">
			<div class="panel-heading">
				<h3 class="panel-title">Add New Supplier</h3>
			</div>
			<div class="panel-body">
                <asp:Label ID="Label3" runat="server" Text="Supplier Name"></asp:Label> &nbsp &nbsp <br />
                <asp:TextBox ID="txtSupName" Cssclass="form-control" runat="server"></asp:TextBox> &nbsp &nbsp <br />
                <asp:Label ID="Label4" runat="server" Text="Supplier Address"></asp:Label> &nbsp &nbsp <br />
                <asp:TextBox ID="txtSupAdd" Cssclass="form-control" runat="server"></asp:TextBox> &nbsp &nbsp <br />
                <asp:Label ID="Label8" runat="server" Text="Supplier Contact Number"></asp:Label>
                <asp:TextBox ID="txtSupCon" Cssclass="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnAddSup" Cssclass="btn btn-md btn-danger" runat="server" Text="Add Supplier Record" />
                <br />
                <br />
                <asp:Panel ID="pnSucc" runat="server" CssClass="alert alert-success"  Visible="False">
                    <asp:Label ID="lblSucc" runat="server" Text="Successfully add new supplier Record."></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnErr" CssClass="alert alert-danger"  runat="server" Visible="False">
                    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
                </asp:Panel>              
            </div>
        </div>
    </div>    
</asp:Content>