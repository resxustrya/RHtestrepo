Public Class Inventory
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        ClearFields()
        LoadItems()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim confirmButton As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim dialogResult As DialogResult
        dialogResult = MessageBox.Show("Do you want to close this window?", "Closing Window", confirmButton)

        If dialogResult = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ItemDescription As String = txtItemDesc.Text
        Dim ItemQty As Integer = Convert.ToInt32(txtItemQty.Text)
        Dim ItemPrice As String = Convert.ToDouble(txtItemPrice.Text)
        Dim ItemDate As String = txtItemDate.Text

        Dim insertCommand As String = "INSERT INTO Item(ItemDesc,Quantity,Price,DateInput) VALUES('" + ItemDescription + "','" + ItemQty.ToString() + "','" + ItemPrice.ToString() + "','" + ItemDate + "');"
        DatabaseConnection.ExecuteCreateUpdateCommands(insertCommand)
        LoadItems()
        ClearFields()

    End Sub

    Private Sub LoadItems()
        Dim itemList As DataTable = DatabaseConnection.ExecuteReadCommands("SELECT * FROM ITEM")
        dgvDisplayItem.DataSource = itemList
    End Sub
    Private Sub ClearFields()
        txtItemDate.Text = String.Empty
        txtItemDesc.Text = String.Empty
        txtItemPrice.Text = String.Empty
        txtItemQty.Text = String.Empty
    End Sub
End Class