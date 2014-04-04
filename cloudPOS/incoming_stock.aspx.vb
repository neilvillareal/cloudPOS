Imports MySql.Data.MySqlClient

Public Class incoming_stock
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

            myDR.Close()
            myCmd.Dispose()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select sup_name from suppliers"
            End With

            myDR = myCmd.ExecuteReader

            While myDR.Read
                cboSupplier.Items.Add(myDR.Item("sup_name").ToString)
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
                .CommandText = "select * from incoming_stock inner join products on incoming_stock.prod_id=products.prod_id order by incoming_stock.date_ordered desc"
            End With

            myDT = New DataTable
            With myDT
                .Columns.Add("Invoice #", GetType(String))
                .Columns.Add("Product ID", GetType(String))
                .Columns.Add("Product Name", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Supplier", GetType(String))
                .Columns.Add("Dated of purchase", GetType(String))
                .Columns.Add("Arrival Date", GetType(String))
            End With

            myDS = New DataSet

            myDR = myCmd.ExecuteReader

            While myDR.Read
                Dim dr As DataRow = myDT.NewRow
                dr("Invoice #") = myDR.Item("inv").ToString
                dr("Product ID") = myDR.Item("prod_id").ToString
                dr("Product Name") = myDR.Item("prod_desc").ToString
                dr("Supplier") = myDR.Item("supplier").ToString
                dr("Quantity") = myDR.Item("qt").ToString
                dr("Dated of Purchase") = Format(myDR.Item("date_ordered"), "MM-dd-yyyy").ToString
                dr("Arrival Date") = Format(myDR.Item("date_arrived"), "MM-dd-yyyy").ToString

                myDT.Rows.Add(dr)
            End While

            myDR.Close()

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
                .CommandText = "select * from incoming_stock inner join products on incoming_stock.prod_id=products.prod_id where incoming_stock.prod_id like @1 or incoming_stock.supplier like @2 or incoming_stock.inv like @3 or products.prod_desc like @4 order by incoming_stock.date_ordered desc"
                .Parameters.AddWithValue("@1", strQue + "%")
                .Parameters.AddWithValue("@2", "%" + strQue + "%")
                .Parameters.AddWithValue("@3", strQue + "%")
                .Parameters.AddWithValue("@4", "%" + strQue + "%")
            End With

            myDT = New DataTable
            With myDT
                .Columns.Add("Invoice #", GetType(String))
                .Columns.Add("Product ID", GetType(String))
                .Columns.Add("Product Name", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Supplier", GetType(String))
                .Columns.Add("Dated of purchase", GetType(String))
                .Columns.Add("Arrival Date", GetType(String))
            End With

            myDS = New DataSet

            myDR = myCmd.ExecuteReader

            While myDR.Read
                Dim dr As DataRow = myDT.NewRow
                dr("Invoice #") = myDR.Item("inv").ToString
                dr("Product ID") = myDR.Item("prod_id").ToString
                dr("Product Name") = myDR.Item("prod_desc").ToString
                dr("Supplier") = myDR.Item("supplier").ToString
                dr("Quantity") = myDR.Item("qt").ToString
                dr("Dated of Purchase") = Format(myDR.Item("date_ordered"), "MM-dd-yyyy").ToString
                dr("Arrival Date") = Format(myDR.Item("date_arrived"), "MM-dd-yyyy").ToString

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

        cdArr.SelectedDate = Now
        cdOrd.SelectedDate = Now
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


            Call dbConnect()

            Dim tArr() As String = Split(cboProd.Text, "|")
            Dim pid As String = Trim(tArr(0))

            myCmd = New MySqlCommand

            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "insert into incoming_stock(prod_id, supplier, qt, date_ordered, date_arrived, inv) values(@1,@2,@3,@4,@5,@6)"
                .Parameters.AddWithValue("@1", pid)
                .Parameters.AddWithValue("@2", cboSupplier.Text)
                .Parameters.AddWithValue("@3", txtQt.Text)
                .Parameters.AddWithValue("@4", Format(cdOrd.SelectedDate, "yyyy-MM-dd"))
                .Parameters.AddWithValue("@5", Format(cdArr.SelectedDate, "yyyy-MM-dd"))
                .Parameters.AddWithValue("@6", Format(Now, "yyyyMMddhhss"))
                .ExecuteNonQuery()
            End With


            txtQt.Text = ""
            cboProd.SelectedIndex = 0
            cboSupplier.SelectedIndex = 0

            pnSucc.Visible = True
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
        Call fillGrid()
        'Response.Redirect("in_coming")
    End Sub
End Class