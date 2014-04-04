<%@ Page Language="vb" MasterPageFile="~/Dashboard.Master" AutoEventWireup="false" CodeBehind="in_stock.aspx.vb" Inherits="cloudPOS.in_stock" %>

<asp:Content runat="server" ID="DashContent" ContentPlaceHolderID="DashContent">
    <br /><br />
    <div class="col-md-12">
        <div class="panel panel-warning">
			<div class="panel-heading">
				<h1 class="panel-title">In Stock Items</h1>
			</div>
			<div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Search..."></asp:Label> &nbsp &nbsp
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> &nbsp &nbsp
                <asp:Button ID="btnSearch" runat="server" Text="Search" /> &nbsp &nbsp
                <asp:Button ID="btnShowAll" runat="server" Text="Show All" /> &nbsp &nbsp
                <br /><br />
                <asp:GridView ID="dgInStock" CssClass ="col-md-12" 
                    runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                    BorderWidth="1px" CellPadding="4">
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
                        <asp:ButtonField Text="Edit" ButtonType="Button"/>
                    </Columns>
                </asp:GridView>
			</div>
		</div>        
    </div>
</asp:Content>