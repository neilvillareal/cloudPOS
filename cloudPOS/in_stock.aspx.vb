Imports MySql.Data.MySqlClient

Public Class in_stock
    Inherits System.Web.UI.Page

    Sub fillGrid()
        Try
            Call dbConnect()
            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select products.cat_name as 'Category', products.prod_id as 'Product ID', products.prod_desc as 'Product Description', products.prod_unit as 'Unit', current_stock.qt as 'Quantity', current_stock.supplier as 'Supplier' from products inner join current_stock on products.prod_id=current_stock.prod_id order by products.prod_desc"
            End With

            myDS = New DataSet
            myDA = New MySqlDataAdapter(myCmd)
            myDA.Fill(myDS)

            With dgInStock
                .AllowPaging = True
                .AllowSorting = True
                .EnableSortingAndPagingCallbacks = True
                .DataSource = myDS.Tables(0)
                .DataBind()
            End With

        Catch ex As Exception

        Finally
            myDA.Dispose()
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

    Sub fillGrid(ByVal strQues As String)
        Try
            Call dbConnect()
            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select products.cat_name as 'Category', products.prod_id as 'Product ID', products.prod_desc as 'Product Description', products.prod_unit as 'Unit', current_stock.qt as 'Quantity', current_stock.supplier as 'Supplier' from products inner join current_stock on products.prod_id=current_stock.prod_id where products.prod_desc like @1 or products.prod_id like @2 or products.cat_name like @3 order by products.prod_desc"
                .Parameters.AddWithValue("@1", "%" + strQues + "%")
                .Parameters.AddWithValue("@2", strQues + "%")
                .Parameters.AddWithValue("@3", "%" + strQues + "%")
            End With

            myDS = New DataSet
            myDA = New MySqlDataAdapter(myCmd)
            myDA.Fill(myDS)

            With dgInStock
                .AllowPaging = False
                .AllowSorting = False
                .EnableSortingAndPagingCallbacks = False
                .DataSource = myDS.Tables(0)
                .DataBind()
            End With

        Catch ex As Exception

        Finally
            myDA.Dispose()
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call fillGrid()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call fillGrid(txtSearch.Text)
    End Sub

    Protected Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        'txtSearch.Text = ""
        'Call fillGrid()
        Response.Redirect("in_stock.aspx")
    End Sub

    Private Sub dgInStock_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dgInStock.RowCommand
        Try
            Dim i As Integer = Convert.ToInt32(e.CommandArgument)
            Dim cd As String = dgInStock.Rows(i).Cells(2).Text
            'MsgBox(cd)

        Catch ex As Exception

        End Try


    End Sub

End Class