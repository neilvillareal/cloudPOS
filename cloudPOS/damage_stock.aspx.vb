Imports MySql.Data.MySqlClient

Public Class damage_stock
    Inherits System.Web.UI.Page

    Sub fillCBO()
        Try
            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select prod_id, prod_desc from products order by prod_desc"
            End With

            myDR = myCmd.ExecuteReader

            While myDR.Read
                cboProd.Items.Add(Trim(myDR.Item("prod_id").ToString) + " | " + Trim(myDR.Item("prod_desc").ToString))
            End While

        Catch ex As Exception

        Finally
            myDR.Close()
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

    Sub fillGrid()
        Try
            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select damage_products.inv as 'Invoice', damage_products.prod_id as 'Product ID', products.prod_desc as 'Product Name', damage_products.qt as 'Quantity', damage_products.dated_mark as 'Dated' from damage_products inner join products on damage_products.prod_id=products.prod_id order by damage_products.dated_mark"
            End With

            myDT = New DataTable
            With myDT
                .Columns.Add("Invoice #", GetType(String))
                .Columns.Add("Product ID", GetType(String))
                .Columns.Add("Product Name", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Dated", GetType(String))
            End With

            myDS = New DataSet

            myDR = myCmd.ExecuteReader

            While myDR.Read
                Dim dr As DataRow = myDT.NewRow
                dr("Invoice #") = myDR.Item("Invoice").ToString
                dr("Product ID") = myDR.Item("Product ID").ToString
                dr("Product Name") = myDR.Item("Product Name").ToString
                dr("Quantity") = myDR.Item("Quantity").ToString
                dr("Dated") = Format(myDR.Item("Dated"), "MM-dd-yyyy")

                myDT.Rows.Add(dr)
            End While

            myDS.Tables.Add(myDT)

            With dgDamStock
                .AllowPaging = True
                .AllowSorting = True
                .EnableSortingAndPagingCallbacks = True
                .DataSource = myDS.Tables(0)
                .DataBind()
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myDR.Close()
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

    Sub fillGrid(ByVal strQue As String)
        Try
            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select damage_products.inv as 'Invoice', damage_products.prod_id as 'Product ID', products.prod_desc as 'Product Name', damage_products.qt as 'Quantity', damage_products.dated_mark as 'Dated' from damage_products inner join products on damage_products.prod_id=products.prod_id where damage_products.prod_id like @1 or products.prod_desc like @2 or damage_products.dated_mark=@3 order by damage_products.dated_mark"
                .Parameters.AddWithValue("@1", strQue + "%")
                .Parameters.AddWithValue("@2", "%" + strQue + "%")
                .Parameters.AddWithValue("@3", strQue)
            End With

            myDT = New DataTable
            With myDT
                .Columns.Add("Invoice #", GetType(String))
                .Columns.Add("Product ID", GetType(String))
                .Columns.Add("Product Name", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Dated", GetType(String))
            End With

            myDS = New DataSet

            myDR = myCmd.ExecuteReader

            While myDR.Read
                Dim dr As DataRow = myDT.NewRow
                dr("Invoice #") = myDR.Item("Invoice").ToString
                dr("Product ID") = myDR.Item("Product ID").ToString
                dr("Product Name") = myDR.Item("Product Name").ToString
                dr("Quantity") = myDR.Item("Quantity").ToString
                dr("Dated") = Format(myDR.Item("Dated"), "MM-dd-yyyy")

                myDT.Rows.Add(dr)
            End While

            myDS.Tables.Add(myDT)

            With dgDamStock
                .AllowPaging = False
                .AllowSorting = False
                .EnableSortingAndPagingCallbacks = False
                .DataSource = myDS.Tables(0)
                .DataBind()
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myDR.Close()
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call fillGrid()
        Call fillCBO()
        cdDate.SelectedDate = Now
    End Sub

    Protected Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Try
            If txtQt.Text = "" Then
                pnErr.Visible = True
                lblErr.Text = "Quantity is empty"
                Exit Sub
            Else
                pnErr.Visible = False
                lblErr.Text = ""
            End If

            Dim tArr() As String = Split(cboProd.Text, "|")
            Dim pid As String = Trim(tArr(0))

            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "insert into damage_products(prod_id, qt, dated_mark, inv) values(@1,@2,@3,@4)"
                .Parameters.AddWithValue("@1", pid)
                .Parameters.AddWithValue("@2", txtQt.Text)
                .Parameters.AddWithValue("@3", Format(cdDate.SelectedDate, "yyyy-MM-dd"))
                .Parameters.AddWithValue("@3", Format(cdDate.SelectedDate, "yyMMddhhss"))
                .ExecuteNonQuery()
            End With

            Call fillGrid()

            cboProd.SelectedIndex = 0
            txtQt.Text = ""
            txtSearch.Text = ""
            cdDate.SelectedDate = Now
        Catch ex As Exception

        Finally
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call fillGrid(txtSearch.Text)
    End Sub

    Protected Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        Call fillGrid()
    End Sub

    Private Sub dgDamStock_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dgDamStock.RowCommand
        Try
            Dim i As Integer = Convert.ToInt32(e.CommandArgument)
            Dim param1, param2 As String
            Dim grv As GridViewRow = dgDamStock.Rows(i)

            param1 = HttpUtility.HtmlDecode(grv.Cells(2).Text).ToString()
            param2 = HttpUtility.HtmlDecode(grv.Cells(3).Text).ToString()
            
            If e.CommandName = "Delete" Then
                Call dbConnect()

                myCmd = New MySqlCommand
                With myCmd
                    .Connection = myCon
                    .CommandType = CommandType.Text
                    .CommandText = "insert into bin_damage_products select * from damage_products where inv=@1 and prod_id=@2"
                    .Parameters.AddWithValue("@1", param1)
                    .Parameters.AddWithValue("@2", param2)
                    .ExecuteNonQuery()
                    .Dispose()
                End With

                myCmd = New MySqlCommand
                With myCmd
                    .Connection = myCon
                    .CommandType = CommandType.Text
                    .CommandText = "delete from damage_products where inv=@1 and prod_id=@2"
                    .Parameters.AddWithValue("@1", param1)
                    .Parameters.AddWithValue("@2", param2)
                    .ExecuteNonQuery()
                    .Dispose()
                End With

                Call fillGrid()
            Else

            End If
        Catch ex As Exception

        Finally
            myCon.Close()
        End Try
    End Sub
    

End Class