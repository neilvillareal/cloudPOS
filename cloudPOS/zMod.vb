Imports MySql.Data.MySqlClient

Module zMod

    Public myCon As MySqlConnection
    Public myCmd As MySqlCommand
    Public myDA As MySqlDataAdapter
    Public myDR As MySqlDataReader
    Public myDT As DataTable
    Public myDS As DataSet

    Public sesUname, sesUtype, sesLname, sesFname As String

    'Public Const strConStr As String = "server=localhost; port=3306; database=cloudPOS; uid=root; pwd=;"
    Public Const strConStr As String = "server=0d0f5fe5-a49f-4ee9-a464-a30300a06849.mysql.sequelizer.com;database=db0d0f5fe5a49f4ee9a464a30300a06849;uid=mbzbntrgruzyasgh;pwd=FfXXGeqQ65F4kvbz5dA2RUqvZApEZvctDb3p8FgyWogKoUeuUDb6qwFTWA7fWSXJ"

    Public Sub dbConnect()
        Try
            myCon = New MySqlConnection(strConStr)
            myCon.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Function loginValidator(ByVal strUsername As String, ByVal strPass As String) As Boolean
        Try
            Call dbConnect()

            myCmd = New MySqlCommand

            With myCmd
                .Connection = myCon
                .CommandType = CommandType.Text
                .CommandText = "select * from users where username=@uname and password=md5(@pass)"
                .Parameters.AddWithValue("@uname", strUsername)
                .Parameters.AddWithValue("@pass", strPass)
            End With

            myDR = myCmd.ExecuteReader
            myDR.Read()

            If myDR.HasRows = False Then
                myDR.Close()
                myCmd.Dispose()
                myCon.Close()
                Return False
            Else
                sesUname = myDR.Item("username")
                sesUtype = myDR.Item("usertype")
                sesLname = myDR.Item("lastname")
                sesFname = myDR.Item("firstname")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myDR.Close()
            myCmd.Dispose()
            myCon.Close()
        End Try

        Return True
    End Function


End Module