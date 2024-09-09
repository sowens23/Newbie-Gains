Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing

Module MainModule
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Dim gearSelector As New GearSelector()
        Dim selectedGear As String = gearSelector.Show()

        Select Case selectedGear
            Case "Helmet"
                Dim helmetCreator As New HelmetCreator()
                helmetCreator.Show()
            Case "Chestplate"
                Dim chestplateCreator As New ChestplateCreator()
                chestplateCreator.Show()
            Case "Leggings"
                Dim leggingsCreator As New LeggingsCreator()
                leggingsCreator.Show()
            Case "Boots"
                Dim bootsCreator As New BootsCreator()
                bootsCreator.Show()
            Case "Jewel"
                Dim jewelCreator As New JewelCreator()
                jewelCreator.Show()
        End Select
    End Sub
End Module

Public Class GearSelector
    Private form As Form
    Private result As String = ""

    Public Function Show() As String
        form = New Form()
        form.Text = "Select Gear Type"
        form.ClientSize = New Size(300, 250)
        form.StartPosition = FormStartPosition.CenterScreen

        Dim label As New Label()
        label.Text = "Select the type of gear you want to create:"
        label.Location = New Point(20, 20)
        label.AutoSize = True
        form.Controls.Add(label)

        Dim gearTypes() As String = {"Helmet", "Chestplate", "Leggings", "Boots", "Jewel"}
        Dim buttonY As Integer = 50

        For Each gearType In gearTypes
            Dim button As New Button()
            button.Text = gearType
            button.Location = New Point(100, buttonY)
            button.Size = New Size(100, 30)
            AddHandler button.Click, AddressOf Button_Click
            form.Controls.Add(button)
            buttonY += 35
        Next

        Application.Run(form)
        Return result
    End Function

    Private Sub Button_Click(sender As Object, e As EventArgs)
        result = DirectCast(sender, Button).Text
        form.Close()
    End Sub
End Class

Public Class HelmetCreator
    Public Sub Show()
        MessageBox.Show("Helmet Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

Public Class ChestplateCreator
    Public Sub Show()
        MessageBox.Show("Chestplate Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

Public Class LeggingsCreator
    Public Sub Show()
        MessageBox.Show("Leggings Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

Public Class BootsCreator
    Public Sub Show()
        MessageBox.Show("Boots Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

Public Class JewelCreator
    Private form As Form
    Private tabControl As TabControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        form = New Form()
        form.Text = "Vault Hunter Jewel Creator"
        form.ClientSize = New Size(500, 600)
        form.StartPosition = FormStartPosition.CenterScreen

        ' Create main panel
        Dim mainPanel As New Panel()
        mainPanel.Dock = DockStyle.Fill
        form.Controls.Add(mainPanel)

        ' Create top space panel (10% of form height)
        Dim topSpace As New Panel()
        topSpace.Height = CInt(form.ClientSize.Height * 0.1)
        topSpace.Dock = DockStyle.Top
        mainPanel.Controls.Add(topSpace)

        ' Create and position TabControl
        tabControl = New TabControl()
        tabControl.Size = New Size(400, 450)
        tabControl.Location = New Point((mainPanel.ClientSize.Width - tabControl.Width) \ 2, topSpace.Height)
        mainPanel.Controls.Add(tabControl)

        ' Create and add tabs
        AddTab("Implicit", {"Jewel Size"})
        AddTab("Prefix", {"Wooden Affinity", "Ornate Affinity", "Gilded Affinity", "Living Affinity", "Picking", "Axing", "Shoveling", "Coin Affinity", "Smelthing", "Pulverizing"})
        AddTab("Suffix", {"Mining Speed", "Durability", "Copiously", "Item Quantity", "Item Rarity", "Soulbound", "Trap Disarming", "Vanilla Immortality", "Reach", "Hammer Size", "Hydrovoid"})

        ' Create button
        Dim createButton As New Button()
        createButton.Text = "Create Jewel"
        createButton.Size = New Size(120, 30)
        createButton.Location = New Point((mainPanel.ClientSize.Width - createButton.Width) \ 2, tabControl.Bottom + 20)
        AddHandler createButton.Click, AddressOf CreateJewel
        mainPanel.Controls.Add(createButton)
    End Sub

    Private Sub AddTab(tabName As String, items As IEnumerable(Of String))
        Dim tabPage As New TabPage(tabName)
        tabControl.TabPages.Add(tabPage)

        Dim panel As New Panel()
        panel.Dock = DockStyle.Fill
        panel.AutoScroll = True
        tabPage.Controls.Add(panel)

        Dim currentY As Integer = 20

        For Each item In items
            Dim label As New Label()
            label.Text = item
            label.Location = New Point(20, currentY)
            label.AutoSize = True
            panel.Controls.Add(label)

            Dim textBox As New TextBox()
            textBox.Location = New Point(180, currentY)
            textBox.Width = 150
            panel.Controls.Add(textBox)

            currentY += 30
        Next
    End Sub

    Private Sub CreateJewel(sender As Object, e As EventArgs)
        MessageBox.Show("Jewel creation logic to be implemented.")
    End Sub

    Public Sub Show()
        Application.Run(form)
    End Sub
End Class