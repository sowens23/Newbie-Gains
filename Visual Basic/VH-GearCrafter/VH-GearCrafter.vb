Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Resources

' Compile: vbc /target:winexe /win32icon:"E:\OneDrive\Documents\GitHub\Newbie-Gains\Visual Basic\VH-GearCrafter\VH-GearCrafter.ico" /out:VH-GearCrafter.exe VH-GearCrafter.vb

Module MainModule
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Dim gearSelector As New GearSelector()
        Dim selectedGear As String = gearSelector.ShowGearSelector()

        Select Case selectedGear
            Case "Helmet"
                Dim helmetCreator As New HelmetCreator()
                MessageBox.Show("Helmet Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' helmetCreator.RunForm()
            Case "Chestplate"
                Dim chestplateCreator As New ChestplateCreator()
                MessageBox.Show("Chestplate Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' chestplateCreator.RunForm()
            Case "Leggings"
                Dim leggingsCreator As New LeggingsCreator()
                MessageBox.Show("Leggings Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' leggingsCreator.RunForm()
            Case "Boots"
                Dim bootsCreator As New BootsCreator()
                MessageBox.Show("Boots Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' bootsCreator.RunForm()
            Case "Jewel"
                Dim jewelCreator As New JewelCreator()
                jewelCreator.RunForm()
        End Select
    End Sub
End Module

' Public Class BaseForm
'     Inherits Form

'     Public Sub New()
'         ' Set the common icon for all forms
'         Try
'             Me.Icon = New Icon("VH-GearCrafter.ico") ' Use the common icon
'         Catch ex As Exception
'             MessageBox.Show("Error loading icon: " & ex.Message)
'         End Try
'     End Sub
' End Class

Public Class GearSelector
    ' Inherits BaseForm ' Inherit from BaseForm
    Private form As Form
    Private result As String = ""

    Public Function ShowGearSelector() As String
        form = New Form()
        form.Text = "Select Gear Type"
        form.ClientSize = New Size(300, 250)
        form.StartPosition = FormStartPosition.CenterScreen
        form.Icon = New Icon("VH-GearCrafter.ico")

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
    Public Sub RunForm()
        MessageBox.Show("Helmet Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

Public Class ChestplateCreator
    Public Sub RunForm()
        MessageBox.Show("Chestplate Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

Public Class LeggingsCreator
    Public Sub RunForm()
        MessageBox.Show("Leggings Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

Public Class BootsCreator
    Public Sub RunForm()
        MessageBox.Show("Boots Creator is under maintenance.", "Under Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

Public Class JewelCreator
    ' Inherits BaseForm ' Inherit from BaseForm
    Private form As Form
    Private tabControl As TabControl
    Private jewelData As New Dictionary(Of String, String)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        form = New Form()
        form.Text = "Vault Hunter: Jewel Creator"
        form.ClientSize = New Size(400, 600)
        form.StartPosition = FormStartPosition.CenterScreen
        form.Icon = New Icon("VH-GearCrafter.ico")

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
        tabControl.Size = New Size(300, 400)
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
            textBox.Width = 40
            panel.Controls.Add(textBox)

            currentY += 30
        Next
    End Sub

    ' Method to collect data from all tabs and textboxes
    Private Sub CreateJewel(sender As Object, e As EventArgs)
        jewelData.Clear() ' Clear previous data if any

        ' Variables to hold JewelSize, PrefixList, and SuffixList
        Dim jewelSize As String = ""
        Dim prefixList As New List(Of String)()
        Dim suffixList As New List(Of String)()

        ' Loop through all TabPages
        For Each tabPage As TabPage In tabControl.TabPages
            ' Iterate over the controls in each tab page in pairs (Label and TextBox)
            Dim controls = tabPage.Controls(0).Controls

            For i As Integer = 0 To controls.Count - 1 Step 2
                ' Ensure we are accessing the label-textbox pairs correctly
                If TypeOf controls(i) Is Label AndAlso TypeOf controls(i + 1) Is TextBox Then
                    Dim label As Label = DirectCast(controls(i), Label)
                    Dim textBox As TextBox = DirectCast(controls(i + 1), TextBox)

                    ' Check if the textbox has a value and is not zero or empty
                    If Not String.IsNullOrWhiteSpace(textBox.Text) AndAlso textBox.Text <> "0" Then
                        Dim inputValue As String = textBox.Text

                        ' Check if we are in the "Implicit" tab (Jewel Size)
                        If tabPage.Text = "Implicit" AndAlso label.Text = "Jewel Size" Then
                            jewelSize = inputValue ' Store the Jewel Size
                        End If

                        ' Check if we are in the "Prefix" tab and add to PrefixList
                        If tabPage.Text = "Prefix" Then
                            ' Additional custom logic for specific Prefixes

                            If label.Text = "Wooden Affinity" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:wooden_affinity"",modifierGroup:""ModAffinity"",modifierIdentifier:""the_vault:wooden_affinity"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Ornate Affinity" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:ornate_affinity"",modifierGroup:""ModAffinity"",modifierIdentifier:""the_vault:ornate_affinity"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Gilded Affinity" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:gilded_affinity"",modifierGroup:""ModAffinity"",modifierIdentifier:""the_vault:gilded_affinity"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Living Affinity" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:living_affinity"",modifierGroup:""ModAffinity"",modifierIdentifier:""the_vault:living_affinity"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Picking" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:picking"",modifierGroup:""ModPicking"",modifierIdentifier:""the_vault:picking"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Axing" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:axing"",modifierGroup:""ModAxing"",modifierIdentifier:""the_vault:axing"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Shoveling" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:shovelling"",modifierGroup:""ModShovelling"",modifierIdentifier:""the_vault:shovelling"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Coin Affinity" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:coin_affinity"",modifierGroup:""ModCoinAffinity"",modifierIdentifier:""the_vault:coin_affinity"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Smelthing" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:smelting"",modifierGroup:""ModSmelting"",modifierIdentifier:""the_vault:smelting"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Pulverizing" AndAlso inputValue = "1" Then
                                prefixList.Add("{category:0,key:""the_vault:pulverizing"",modifierGroup:""ModPulverizing"",modifierIdentifier:""the_vault:pulverizing"",rolledTier:0,value:""true""}")
                            End If

                        End If

                        ' Check if we are in the "Suffix" tab and add to SuffixList
                        If tabPage.Text = "Suffix" Then
                          ' Additional custom logic for specific Suffixes

                            If label.Text = "Mining Speed" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:mining_speed"",modifierGroup:""ModMiningSpeed"",modifierIdentifier:""the_vault:mining_speed"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Durability" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:durability"",modifierGroup:""ModDurability"",modifierIdentifier:""the_vault:durability"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Copiously" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:copiously"",modifierGroup:""ModCopiously"",modifierIdentifier:""the_vault:copiously"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Item Quantity" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:item_quantity"",modifierGroup:""ModLoot"",modifierIdentifier:""the_vault:item_quantity"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Item Rarity" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:item_rarity"",modifierGroup:""ModLoot"",modifierIdentifier:""the_vault:item_rarity"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Soulbound" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:soulbound"",modifierGroup:""ModSoulbound"",modifierIdentifier:""the_vault:soulbound"",rolledTier:0,value:""true""}")
                            End If

                            If label.Text = "Trap Disarming" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:trap_disarming"",modifierGroup:""ModTrapDisarm"",modifierIdentifier:""the_vault:trap_disarming"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Vanilla Immortality" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:immortality"",modifierGroup:""ModImmortality"",modifierIdentifier:""the_vault:immortality"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Reach" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:reach"",modifierGroup:""ModReach"",modifierIdentifier:""the_vault:reach"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Hammer Size" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:hammer_size"",modifierGroup:""ModReach"",modifierIdentifier:""the_vault:hammer_size"",rolledTier:0,value:" & inputValue & "}")
                            End If

                            If label.Text = "Hydrovoid" AndAlso inputValue > "0" Then
                                suffixList.Add("{category:0,key:""the_vault:hydrovoid"",modifierGroup:""ModHydrovoidAffinity"",modifierIdentifier:""the_vault:hydrovoid"",rolledTier:0,value:""true""}")
                            End If

                        End If
                    End If
                End If
            Next
        Next

        ' Build the final NBT data string using the template
        Dim nbtData As String = "the_vault:jewel{nbtGearData:{baseModifiers:[{category:0,key:""the_vault:jewel_size"",modifierGroup:""BaseJewelSize"",modifierIdentifier:""the_vault:jewel_size"",rolledTier:0,value:" & jewelSize & "}],rarity:1,repairSlots:4,state:2,usedRepairSlots:0,version:2,itemLevel:0,prefixes:[" & String.Join(",", prefixList) & "],suffixes:[" & String.Join(",", suffixList) & "]}}"

        ' Call custom form to display the NBT data and provide "Copy NBT data" functionality
        ShowNBTDataForm(nbtData)
    End Sub

    ' Custom form to show the NBT data and copy to clipboard
    Private Sub ShowNBTDataForm(nbtData As String)
        ' Create a new form
        Dim infoForm As New Form()
        infoForm.Text = "NBT Data"
        infoForm.Size = New Size(500, 300)
        infoForm.StartPosition = FormStartPosition.CenterScreen
        infoForm.Icon = New Icon("VH-GearCrafter.ico")

        ' Display text instructions
        Dim steps As New List(Of String) From {
            "Steps to create custom jewel:", 
            "1) Get a command block with: /give @p minecraft:command_block", 
            "2) Place it, and fill this command inside the command block", 
            "3) /give @p **NBT_CODE**", 
            "4) Craft a button, place on top of the Command Block, and press it.", 
            "5) While holding the Jewel in main hand use this command: /the_vault gear_debug pack - this will apply the properties."
        }

        dim currentY As Integer = 30
        For Each stepText In steps
            Dim stepLabel As New Label()
            stepLabel.Text = stepText
            stepLabel.Location = New Point(20, currentY)
            stepLabel.AutoSize = True
            infoForm.Controls.Add(stepLabel)

            currentY += 20
        Next


        ' Create a TextBox to display the NBT data
        Dim infoTextBox As New TextBox()
        infoTextBox.Multiline = True
        infoTextBox.ReadOnly = True
        infoTextBox.Size = New Size(300, 50)
        infoTextBox.Location = New Point(50, currentY)
        infoTextBox.Text = nbtData
        infoTextBox.ScrollBars = ScrollBars.Vertical
        infoForm.Controls.Add(infoTextBox)

        ' Create OK button
        Dim okButton As New Button()
        okButton.Text = "OK"
        okButton.Size = New Size(80, 30)
        okButton.Location = New Point(100, 220)
        AddHandler okButton.Click, Sub(sender, e) infoForm.Close()
        infoForm.Controls.Add(okButton)

        ' Create Copy NBT Data button
        Dim copyButton As New Button()
        copyButton.Text = "Copy NBT Data"
        copyButton.Size = New Size(120, 30)
        copyButton.Location = New Point(200, 220)
        AddHandler copyButton.Click, Sub(sender, e)
                                        Clipboard.SetText(nbtData)
                                        MessageBox.Show("NBT data copied to clipboard!")
                                    End Sub
        infoForm.Controls.Add(copyButton)

        ' Show the custom form
        infoForm.ShowDialog()
    End Sub

    Public Sub RunForm()
        Application.Run(form)
    End Sub
End Class