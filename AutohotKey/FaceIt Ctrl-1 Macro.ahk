; ToolTip Mouse Menu (based on the v1 script by Rajat)
; https://www.autohotkey.com
; This script displays a popup menu in response to briefly holding down
; the middle mouse button.  Select a menu item by left-clicking it.
; Cancel the menu by left-clicking outside of it.  A recent improvement
; is that the contents of the menu can change depending on which type of
; window is active (Notepad and Word are used as examples here).

; You can set any title here for the menu:
g_MenuTitle := "-~::~~--~~::~-"

; This is how long the mouse button must be held to cause the menu to appear:
g_UMDelay := 20

; #SingleInstance


;___________________________________________
;_____Menu Definitions______________________

; Create / Edit Menu Items here.
; You can't use spaces in keys/values/section names.

; Don't worry about the order, the menu will be sorted.

g_MenuItems := "DrawOver/WhiteBoard/BlackBoard/Exit"

; Exit

;___________________________________________
;_____Menu Sections_________________________

; Create / Edit Menu Sections here.

DrawOver()
{
    Send("^1")
    Sleep 100
    Send("g")   
}

WhiteBoard()
{
    Send("^1")
    Sleep 100
    Send("w")   
}

BlackBoard()
{
    Send("^1")
    Sleep 100
    Send("b")
}

Exit()
{
	ExitApp()
}

;___________________________________________
;_____Hotkey Section________________________

~Esc:: {
    ExitApp()
}

; RButton::
; {
    ; HowLong := 0
    ; Loop
    ; {
    ;     HowLong++
    ;     Sleep 10
    ;     if !GetKeyState("MButton", "P")
    ;         Break
    ; }
    ; if HowLong < g_UMDelay
    ;     return


    ; Joins sorted main menu and dynamic menu, and
    ; clears earlier entries and creates new entries:
    MenuItem := StrSplit(g_MenuItems, "/")

    ; Creates the menu:
    ToolTipMenu := g_MenuTitle
    For i, item in MenuItem
        ToolTipMenu .= "`n" item

    MouseGetPos &mX, &mY
    Hotkey "~LButton", MenuClick
    Hotkey "~LButton", "On"
    ToolTip ToolTipMenu, SysGet(78)*0.99, SysGet(79)*0.2
    WinActivate g_MenuTitle
    WinGetPos ,,, &tH, g_MenuTitle
    
    MenuClick(*)
    {
        Hotkey "~LButton", "Off"
        if !WinActive(g_MenuTitle)
        {
            ; ToolTip
            ; return
            ExitApp()
        }

        MouseGetPos &mX, &mY
        ToolTip
        mY /= tH / (MenuItem.Length + 1)  ; Space taken by each line.
        if mY < 1
            return
        TargetSection := MenuItem[Integer(mY)]
        %StrReplace(TargetSection, "`s")%()
    }
; }