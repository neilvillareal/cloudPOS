Imports MySql.Data.MySqlClient

Public Class categories
    Inherits System.Web.UI.Page

    Dim ctr As Integer = 0

    Sub fillGrid()
        Try
            Call dbConnect()
            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select cat_name as 'Category', cat_desc as 'Description' from categories"
            End With

            myDS = New DataSet
            myDA = New MySqlDataAdapter(myCmd)
            myDA.Fill(myDS, "categories")

            With dgCategories
                .DataSource = myDS.Tables("categories")
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
                .CommandText = "select cat_name as 'Category', cat_desc as 'Description' from categories where cat_name like @1 or cat_desc like @2"
                .Parameters.AddWithValue("@1", "%" + strQue + "%")
                .Parameters.AddWithValue("@2", "%" + strQue + "%")
            End With

            myDS = New DataSet
            myDA = New MySqlDataAdapter(myCmd)
            myDA.Fill(myDS, "categories")

            With dgCategories
                .DataSource = myDS.Tables("categories")
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

    Protected Sub btnAddCat_Click(sender As Object, e As EventArgs) Handles btnAddCat.Click
        Try
            If txtCatName.Text = "" Then
                pnErr.Visible = True
                lblErr.Text = "Category name is empty."
                Exit Sub
            Else
                pnErr.Visible = False
                lblErr.Text = ""
            End If

            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select cat_name from categories where cat_name=@1"
                .Parameters.AddWithValue("@1", txtCatName.Text)
            End With

            myDR = myCmd.ExecuteReader
            myDR.Read()

            If myDR.HasRows = True Then
                myDR.Close()
                myCmd.Dispose()
                myCon.Close()
                pnErr.Visible = True
                lblErr.Text = "Category already exists."
                Exit Sub
            Else
                pnErr.Visible = False
                lblErr.Text = ""
            End If

            myDR.Close()
            myCmd.Dispose()

            myCmd = New MySqlCommand

            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "insert into categories(cat_name, cat_desc) values(@1,@2)"
                .Parameters.AddWithValue("@1", txtCatName.Text)
                .Parameters.AddWithValue("@2", txtDesc.Text)
                .ExecuteNonQuery()
            End With

            pnSucc.Visible = True
            txtCatName.Text = ""
            txtDesc.Text = ""

            Call fillGrid()
        Catch ex As Exception

        Finally
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

    Protected Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        Response.Redirect("categories.aspx")
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call fillGrid(txtSearch.Text)
    End Sub
End Class