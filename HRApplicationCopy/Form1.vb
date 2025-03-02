Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub CloseChildForms()
        Dim childForm As Form
        For Each childForm In Me.MdiChildren
            childForm.Close()
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim inventory As Inventory = New Inventory()
        CloseChildForms()
        inventory.MdiParent = Me
        inventory.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim delivery As Delivery = New Delivery()
        CloseChildForms()
        delivery.MdiParent = Me
        delivery.Show()
    End Sub
End Class