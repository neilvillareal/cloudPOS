<%@ Page Language="vb" MasterPageFile="~/Dashboard.Master" AutoEventWireup="false" CodeBehind="categories.aspx.vb" Inherits="cloudPOS.categories" %>

<asp:Content runat="server" ID="DashContent" ContentPlaceHolderID="DashContent">
    <br /><br />
     <div class="col-md-8">
        <div class="panel panel-primary">
	        <div class="panel-heading">
		        <h3 class="panel-title">Categories</h3>
	        </div>
	        <div class="panel-body">
                <asp:Label ID="Label3" runat="server" Text="Search..."></asp:Label> &nbsp &nbsp
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> &nbsp &nbsp
                <asp:Button ID="btnSearch" runat="server" Text="Search" /> &nbsp &nbsp
                <asp:Button ID="btnShowAll" runat="server" Text="Show All" /> &nbsp &nbsp
                <br /><br />
                <asp:GridView ID="dgCategories" runat="server" CellPadding="3" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EnableSortingAndPagingCallbacks="True">
                <AlternatingRowStyle BackColor="#99CCFF" />
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#99CCCC" ForeColor="White" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                <Columns>
                    <asp:ButtonField Text="Delete" ButtonType="Button" CommandName ="Delete"/>
                    <asp:ButtonField Text="Edit" ButtonType="Button" CommandName ="Edit" />
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
    
    <div class="col-md-4">
        <div class="panel panel-primary">
	        <div class="panel-heading">
		        <h3 class="panel-title">Add New Category</h3>
	        </div>
	        <div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
		        <asp:TextBox ID="txtCatName" Cssclass="form-control col-md-12" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="txtDesc" Cssclass="form-control col-md-12" runat="server"></asp:TextBox>
                <br /><br /><br />
                <asp:Button ID="btnAddCat" Cssclass="btn btn-md btn-danger" runat="server" Text="Add Category" />
                <br /><br />
                <asp:Panel ID="pnErr" runat="server" CssClass="alert alert-danger" Visible="False">
                    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <asp:Panel ID="pnSucc" runat="server" CssClass="alert alert-success"  Visible="False">
                    <asp:Label ID="lblSucc" runat="server" Text="Successfully add new category."></asp:Label>
                </asp:Panel>
	        </div>
        </div>
    </div>
   
</asp:Content>