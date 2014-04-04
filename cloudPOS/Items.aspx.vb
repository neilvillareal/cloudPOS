Imports MySql.Data.MySqlClient

Public Class Items
    Inherits System.Web.UI.Page

    Sub fillGrid()
        Try
            Call dbConnect()
            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select cat_name as 'Category', prod_id as 'Product ID', prod_desc as 'Product Description', prod_unit as 'Unit' from products order by prod_desc"
            End With

            myDS = New DataSet
            myDA = New MySqlDataAdapter(myCmd)
            myDA.Fill(myDS, "products")

            With dgProducts
                .AllowPaging = True
                .AllowSorting = True
                .EnableSortingAndPagingCallbacks = True
                .DataSource = myDS.Tables("products")
                .DataBind()
            End With

        Catch ex As Exception

        Finally
            myDA.Dispose()
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
                .CommandText = "select cat_name as 'Category', prod_id as 'Product ID', prod_desc as 'Product Description', prod_unit as 'Unit' from products where prod_desc like @1 or prod_id like @2 or cat_name like @3 order by prod_desc"
                .Parameters.AddWithValue("@1", "%" + strQue + "%")
                .Parameters.AddWithValue("@2", strQue + "%")
                .Parameters.AddWithValue("@3", "%" + strQue + "%")
            End With

            myDS = New DataSet
            myDA = New MySqlDataAdapter(myCmd)
            myDA.Fill(myDS, "products")

            With dgProducts
                .AllowPaging = False
                .AllowSorting = False
                .EnableSortingAndPagingCallbacks = False
                .DataSource = myDS.Tables("products")
                .DataBind()
            End With

        Catch ex As Exception

        Finally
            myDA.Dispose()
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

    Sub fillFields()
        Try
            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select cat_name from categories order by cat_name"
            End With

            myDR = myCmd.ExecuteReader
            While myDR.Read
                cboCat.Items.Add(myDR.Item(0).ToString)
            End While

            cboCat.Items.Add("Others")

        Catch ex As Exception

        Finally
            myDR.Close()
            myCmd.Dispose()
            myCon.Close()
            cboCat.SelectedIndex = 0
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call fillFields()
        Call fillGrid()
    End Sub

    Protected Sub btnAddProd_Click(sender As Object, e As EventArgs) Handles btnAddProd.Click
        Try
            If txtProdID.Text = "" Or txtProdName.Text = "" Or txtProdPrice.Text = "" Then
                pnErr.Visible = True
                Exit Sub
            Else
                pnErr.Visible = False
            End If

            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "insert into products(cat_name, prod_id, prod_desc, prod_price, prod_unit) values(@1,@2,@3,@4,@5)"
                .Parameters.AddWithValue("@1", cboCat.Text)
                .Parameters.AddWithValue("@2", txtProdID.Text)
                .Parameters.AddWithValue("@3", txtProdName.Text)
                .Parameters.AddWithValue("@4", txtProdPrice.Text)
                .Parameters.AddWithValue("@5", txtUnit.Text)
                .ExecuteNonQuery()
            End With

            txtProdID.Text = ""
            txtProdName.Text = ""
            txtProdPrice.Text = ""
            txtUnit.Text = ""
            cboCat.Text = ""
            Call fillGrid()
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
        'txtSearch.Text = ""
        'Call fillGrid()
        Response.Redirect("Items.aspx")
    End Sub

    Private Sub dgProducts_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dgProducts.RowCommand
        Try
            Dim i As Integer = Convert.ToInt32(e.CommandArgument)
            Dim dgr As GridViewRow = dgProducts.Rows(i)
            Dim pid As String = HttpUtility.HtmlDecode(dgr.Cells(3).Text).ToString()

            If e.CommandName = "Delete" Then
                Dim ans As MsgBoxResult = MsgBox("Delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")

                If ans = MsgBoxResult.No Then
                    Response.Redirect("Items.aspx")
                    Exit Sub
                End If

                Call dbConnect()

                myCmd = New MySqlCommand
                With myCmd
                    .Connection = myCon
                    .CommandType = CommandType.Text
                    .CommandText = "insert into bin_products select * from products where prod_id=@1"
                    .Parameters.AddWithValue("@1", pid)
                    .ExecuteNonQuery()
                    .Dispose()
                End With

                myCmd = New MySqlCommand
                With myCmd
                    .Connection = myCon
                    .CommandType = CommandType.Text
                    .CommandText = "delete from products where prod_id=@1"
                    .Parameters.AddWithValue("@1", pid)
                    .ExecuteNonQuery()
                    .Dispose()
                End With

                myCon.Close()
                Response.Redirect("Items.aspx")
            Else


            End If
        Catch ex As Exception

        End Try
    End Sub

End Class