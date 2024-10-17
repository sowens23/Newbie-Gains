#Requires AutoHotkey v2.0

; Send Ctrl + 1
Send("^1")

; Create a small window with two buttons
MyGui := GuiCreate("-Caption +ToolWindow +AlwaysOnTop")
MyGui.SetFont("s12", "Verdana")
MyGui.MarginY := 0
MyGui.MarginX := 0

; Add buttons
MyGui.AddButton("w100 h30 gButtonG", "Send G")
MyGui.AddButton("w100 h30 x+10 gButtonEsc", "Send Escape")

; Show the GUI
MyGui.Show("w220 h60", "Choose an action")

; Define button actions
ButtonG(*) {
    Send("g")
    ExitApp()
}

ButtonEsc(*) {
    Send("{Escape}")
    ExitApp()
}

; Ensure the script exits when the GUI is closed
MyGui.OnEvent("Close", (*) => ExitApp())
