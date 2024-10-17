#Requires AutoHotkey v2.0

MyMenu := Menu()
MyMenuBar := MenuBar()
MyMenu := Menu.Call()
MyMenuBar := MenuBar.Call()

MyMenu.Add("Blue", CloseDraw())

CloseDraw()
{
	MsgBox "You selected 4"
	; ExitApp()
}

MyMenu.Show(SysGet(78)*0.99, SysGet(79)*0.2)

; ButtonG(*) {
;     Send("g")
;     ExitApp()
; }

; ButtonEsc(*) {
;     Send("{Escape}")
;     ExitApp()
; }

 ; Send Ctrl + 1
; Send("^1")
;