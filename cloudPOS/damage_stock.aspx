<%@ Page Language="vb" MasterPageFile="~/Dashboard.Master" AutoEventWireup="false" CodeBehind="damage_stock.aspx.vb" Inherits="cloudPOS.damage_stock" %>

<asp:Content runat="server" ID="DashContent" ContentPlaceHolderID="DashContent">
    <br /><br />
    <div class="col-md-8">
        <div class="panel panel-primary">
			<div class="panel-heading">
				<h1 class="panel-title">Damage Items</h1>
			</div>
			<div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Search..."></asp:Label> &nbsp &nbsp
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> &nbsp &nbsp
                <asp:Button ID="btnSearch" runat="server" Text="Search" /> &nbsp &nbsp
                <asp:Button ID="btnShowAll" runat="server" Text="Show All" /> &nbsp &nbsp
                <br /><br />
                <asp:GridView ID="dgDamStock" CssClass ="col-md-12" 
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
				<h1 class="panel-title">Add Damage Item</h1>
			</div>
			<div class="panel-body">                
			    <asp:Label ID="Product" runat="server" Text="Product"></asp:Label>
                <asp:DropDownList ID="cboProd" runat="server" Cssclass="col-md-12 form-control" >
                </asp:DropDownList>
                <br />
                <asp:Label ID="Quantity" runat="server" Text="Quantity"></asp:Label>
                <asp:TextBox ID="txtQt" runat="server" Cssclass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Dated"></asp:Label>
                <asp:Calendar ID="cdDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
                <br />
                <asp:Button ID="btnAddItem" Cssclass="btn btn-md btn-danger" runat="server" Text="Add Item" />
                <br /><br />

                <asp:Panel ID="pnErr" runat="server" CssClass="alert alert-danger" Visible="False">
                    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <asp:Panel ID="pnSucc" runat="server" CssClass="alert alert-success"  Visible="False">
                    <asp:Label ID="lblSucc" runat="server" Text="Successfully add new record."></asp:Label>
                </asp:Panel>
			</div>
		</div>        
    </div>
</asp:Content>