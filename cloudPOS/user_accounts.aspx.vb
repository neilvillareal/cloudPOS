Imports MySql.Data.MySqlClient

Public Class user_accounts
    Inherits System.Web.UI.Page

    Sub fillGrid()
        Try
            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select username as 'Username', usertype as 'Usertype', lastname as 'Lastname', firstname as 'Firstname', middlename as 'Middlename' from users"
            End With

            myDS = New DataSet
            myDA = New MySqlDataAdapter(myCmd)
            myDA.Fill(myDS, "users")

            With dgUsers
                .DataSource = myDS.Tables("users")
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
        With cboUtype
            .Items.Add("Cashier")
            .Items.Add("Admin")
        End With

        Call fillGrid()
    End Sub

    Function checkIfUnameExist(ByVal strUname As String) As Boolean
        Try
            Call dbConnect()

            myCmd = New MySqlCommand
            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select * from users where username=@1"
                .Parameters.AddWithValue("@1", strUname)
            End With

            myDR = myCmd.ExecuteReader
            myDR.Read()

            If myDR.HasRows = True Then
                myDR.Close()
                myCmd.Dispose()
                myCon.Close()
                Return False
            End If

        Catch ex As Exception

        Finally
            myDR.Close()
            myCmd.Dispose()
            myCon.Close()
        End Try

        Return False
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If checkIfUnameExist(txtUsername.Text) = True Then
                lblErr.Text = "Username already exist"
                pnErr.Visible = True
                Exit Sub
            Else
                pnErr.Visible = False
            End If

            If txtCPass.Text = "" Or txtFirstname.Text = "" Or txtLastname.Text = "" Or txtMiddlename.Text = "" Or txtPassword.Text = "" Or txtUsername.Text = "" Then
                lblErr.Text = "Please fill required data"
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
                .CommandText = "insert into users(username, password, lastname, firstname, middlename, usertype) values(@1,@2,@3,@4,@5,@6)"
                .Parameters.AddWithValue("@1", txtUsername.Text)
                .Parameters.AddWithValue("@2", txtPassword.Text)
                .Parameters.AddWithValue("@3", txtLastname.Text)
                .Parameters.AddWithValue("@4", txtFirstname.Text)
                .Parameters.AddWithValue("@5", txtMiddlename.Text)
                .Parameters.AddWithValue("@6", cboUtype.Text)
                .ExecuteNonQuery()
            End With

            txtCPass.Text = ""
            txtFirstname.Text = ""
            txtLastname.Text = ""
            txtMiddlename.Text = ""
            txtPassword.Text = ""
            txtUsername.Text = ""
            cboUtype.SelectedIndex = 0

            Call fillGrid()

        Catch ex As Exception

        Finally
            myCmd.Dispose()
            myCon.Close()
            pnSucc.Visible = True
        End Try

    End Sub

End Class