Imports System
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class print_reports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub listProducts()
        Dim doc As Document = New Document
        PdfWriter.GetInstance(doc, New FileStream(Request.PhysicalApplicationPath + "\product_list.pdf", FileMode.Create))
        doc.Open()

        Dim table As Table = New Table(5)
        table.BorderWidth = 1
        table.BorderColor = New Color(0, 0, 0)
        table.Padding = 3
        table.Spacing = 1
        Dim cell1 As Cell = New Cell("header")


    End Sub

End Class