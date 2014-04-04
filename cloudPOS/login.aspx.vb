Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtUsername.Focus()
        pnErr.Visible = False
    End Sub

    Protected Sub btnSignIn_Click(sender As Object, e As EventArgs) Handles btnSignIn.Click
        If txtUsername.Text.Length <= 0 Then
            txtUsername.Focus()
            Exit Sub
        End If

        If txtPassword.Text = "" Then
            txtPassword.Focus()
            Exit Sub
        End If

        If loginValidator(txtUsername.Text, txtPassword.Text) = True Then
            With Session
                .Add("username", sesUname)
                .Add("usertype", sesUtype)
                .Add("lastname", sesLname)
                .Add("firstname", sesFname)
            End With

            Response.Redirect("dashboard.aspx")
        Else
            txtPassword.Text = ""
            txtUsername.Text = ""
            txtUsername.Focus()
            pnErr.Visible = True
        End If
    End Sub
End Class