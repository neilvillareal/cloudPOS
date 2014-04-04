<%@ Page Language="vb" MasterPageFile="~/Dashboard.Master" AutoEventWireup="false" CodeBehind="Items.aspx.vb" Inherits="cloudPOS.Items" %>

<asp:Content runat="server" ID="DashContent" ContentPlaceHolderID="DashContent">
    <br /><br />
    <div class="col-md-9">
        <div class="panel panel-primary">
			<div class="panel-heading">
				<h1 class="panel-title">Items</h1>
			</div>
			<div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Search..."></asp:Label> &nbsp &nbsp
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> &nbsp &nbsp
                <asp:Button ID="btnSearch" runat="server" Text="Search" /> &nbsp &nbsp
                <asp:Button ID="btnShowAll" runat="server" Text="Show All" /> &nbsp &nbsp
                <br /><br />
                <asp:GridView ID="dgProducts" CssClass ="col-md-12" 
                    runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                    BorderWidth="1px" CellPadding="4" AllowPaging="True" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="White" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                    <Columns>
                        <asp:ButtonField Text="Select" CommandName="Select" ButtonType="Button" />
                        <asp:ButtonField Text="Delete" CommandName="Delete" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
			</div>
		</div>        
    </div>
    <div class="col-md-3">
        <div class="panel panel-primary">
			<div class="panel-heading">
				<h3 class="panel-title">Add New Item</h3>
			</div>
			<div class="panel-body">
				<asp:Label ID="Label3" runat="server" Text="Product ID *"></asp:Label> &nbsp &nbsp <br />
                <asp:TextBox ID="txtProdID" Cssclass="form-control" runat="server"></asp:TextBox> &nbsp &nbsp <br />
                <asp:Label ID="Label4" runat="server" Text="Product Name *"></asp:Label> &nbsp &nbsp <br />
                <asp:TextBox ID="txtProdName" Cssclass="form-control" runat="server"></asp:TextBox> &nbsp &nbsp <br />
                <asp:Label ID="Label6" runat="server" Text="Price *"></asp:Label>&nbsp &nbsp <br />
                <asp:TextBox ID="txtProdPrice" Cssclass="form-control" runat="server"></asp:TextBox>&nbsp &nbsp <br />
                <asp:Label ID="Label8" runat="server" Text="Product Unit"></asp:Label>
                <asp:TextBox ID="txtUnit" Cssclass="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label>&nbsp &nbsp <br />
                <asp:DropDownList ID="cboCat" Cssclass="form-control"  runat="server">
                </asp:DropDownList>
                <br />
                <asp:Button ID="btnAddProd" Cssclass="btn btn-md btn-danger" runat="server" Text="Add Item" />
                <br /><br />
                <asp:Label ID="Label9" runat="server" Text="*Required"></asp:Label>
                <br /><br />
			    <asp:Panel ID="pnErr" CssClass="alert alert-danger"  runat="server" Visible="False">
                    <asp:Label ID="Label7" runat="server" Text="Please fill required data"></asp:Label>
                </asp:Panel>
			</div>
		</div>
    </div>
</asp:Content>