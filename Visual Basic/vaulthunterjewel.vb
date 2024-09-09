Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing

Module VaultHunterJewelCreator

  Sub Main()
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(False)

    Dim Implicit_List As New List(Of String) From {
      "Jewel Size"
    }

    Dim Prefix_List As New List(Of String) From {
      "Wooden Affinity ", "Ornate Affinity", "Gilded Affinity", "Living Affinity", "Picking", "Axing", "Shoveling", "Coin Affinity", "Smelthing", "Pulverizing"
    }

    Dim Suffix_List As New List(Of String) From {
      "Mining Speed", "Durability", "Copiously", "Item Quantity", "Item Rarity", "Soulbound", "Trap Disarming", "Vanilla Immortality", "Reach", "Hammer Size", "Hydrovoid"
    }

    ' Create the Form and set its properties
    Dim form As New Form()
    form.Text = "Vault Hunter Jewel Creator"
    form.ClientSize = New Size(400, 800)

    ' Create a panel to hold the controls
    Dim panel As New Panel()
    panel.Dock = DockStyle.Fill
    panel.AutoScroll = True
    form.Controls.Add(panel)

    Dim currentY As Integer = 20

    ' Function to add labels and textboxes for a list
    Dim addControlsForList = Sub(list As List(Of String), title As String)
                               Dim titleLabel As New Label()
                               titleLabel.Text = title
                               titleLabel.Location = New Point(20, currentY)
                               titleLabel.AutoSize = True
                               panel.Controls.Add(titleLabel)
                               currentY += 25

                               For Each item In list
                                 Dim label As New Label()
                                 label.Text = item
                                 label.Location = New Point(20, currentY)
                                 label.AutoSize = True
                                 panel.Controls.Add(label)

                                 Dim textBox As New TextBox()
                                 textBox.Location = New Point(180, currentY)
                                 textBox.Width = 200
                                 panel.Controls.Add(textBox)

                                 currentY += 25
                               Next

                               currentY += 20  ' Add some space between sections
                             End Sub

    ' Add controls for each list
    addControlsForList(Implicit_List, "Implicit")
    addControlsForList(Prefix_List, "Prefix  (0 = No, 1 = Yes)")
    addControlsForList(Suffix_List, "Suffix")

    ' Add a button to create the jewel
    Dim createButton As New Button()
    createButton.Text = "Create Jewel"
    createButton.Location = New Point(150, currentY)
    AddHandler createButton.Click, AddressOf CreateJewel
    panel.Controls.Add(createButton)

    Application.Run(form)
  End Sub

  Sub CreateJewel(sender As Object, e As EventArgs)
    ' Add your jewel creation logic here
    MessageBox.Show("Jewel creation logic to be implemented.")
  End Sub

End Module