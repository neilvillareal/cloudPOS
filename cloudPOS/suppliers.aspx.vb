Imports MySql.Data.MySqlClient

Public Class suppliers
    Inherits System.Web.UI.Page

    Sub fillGrid()
        Try
            Call dbConnect()
            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select sup_name as 'Supplier', sup_address as 'Address', sup_contact as 'Contact' from suppliers"
            End With

            myDS = New DataSet
            myDA = New MySqlDataAdapter(myCmd)
            myDA.Fill(myDS, "suppliers")

            With dgSuppliers
                .DataSource = myDS.Tables("suppliers")
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

    Protected Sub btnAddSup_Click(sender As Object, e As EventArgs) Handles btnAddSup.Click
        Try
            If txtSupName.Text = "" Then
                lblErr.Text = "Supplier name is empty."
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
                .CommandText = "select * from suppliers where sup_name like @1"
                .Parameters.AddWithValue("@1", "'" + txtSupName.Text + "%'")
            End With

            myDR = myCmd.ExecuteReader
            myDR.Read()

            If myDR.HasRows = True Then
                myDR.Close()
                myCmd.Dispose()
                myCon.Close()
                pnErr.Visible = True
                lblErr.Text = "Supplier record already exists"
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
                .CommandText = "insert into suppliers(sup_name, sup_address, sup_contact) values(@1,@2,@3)"
                .Parameters.AddWithValue("@1", txtSupName.Text)
                .Parameters.AddWithValue("@2", txtSupAdd.Text)
                .Parameters.AddWithValue("@3", txtSupCon.Text)
                .ExecuteNonQuery()
            End With

            txtSupAdd.Text = ""
            txtSupCon.Text = ""
            txtSupName.Text = ""
            txtSupName.Focus()

            Call fillGrid()
            pnSucc.Visible = True

        Catch ex As Exception

        Finally
            myCmd.Dispose()
            myCon.Close()
        End Try
    End Sub

End Class