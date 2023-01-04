namespace CoTools.Native.User32.Constants
{
    public static class Event
    {

        public static readonly uint

            MIN = 0x00000001,

            MAX = 0x7FFFFFFF,

            SYSTEM_SOUND = 0x0001,

            SYSTEM_ALERT = 0x0002,

            SYSTEM_FOREGROUND = 0x0003,

            SYSTEM_MENUSTART = 0x0004,

            SYSTEM_MENUEND = 0x0005,

            SYSTEM_MENUPOPUPSTART = 0x0006,

            SYSTEM_MENUPOPUPEND = 0x0007,

            SYSTEM_CAPTURESTART = 0x0008,

            SYSTEM_CAPTUREEND = 0x0009,

            SYSTEM_MOVESIZESTART = 0x000A,

            SYSTEM_MOVESIZEEND = 0x000B,

            SYSTEM_CONTEXTHELPSTART = 0x000C,

            SYSTEM_CONTEXTHELPEND = 0x000D,

            SYSTEM_DRAGDROPSTART = 0x000E,

            SYSTEM_DRAGDROPEND = 0x000F,

            SYSTEM_DIALOGSTART = 0x0010,

            SYSTEM_DIALOGEND = 0x0011,

            SYSTEM_SCROLLINGSTART = 0x0012,

            SYSTEM_SCROLLINGEND = 0x0013,

            SYSTEM_SWITCHSTART = 0x0014,

            SYSTEM_SWITCHEND = 0x0015,

            SYSTEM_MINIMIZESTART = 0x0016,

            SYSTEM_MINIMIZEEND = 0x0017,

            SYSTEM_DESKTOPSWITCH = 0x0020,

            SYSTEM_END = 0x00FF,

            OEM_DEFINED_START = 0x0101,

            OEM_DEFINED_END = 0x01FF,

            UIA_EVENTID_START = 0x4E00,

            UIA_EVENTID_END = 0x4EFF,

            UIA_PROPID_START = 0x7500,

            UIA_PROPID_END = 0x75FF,

            CONSOLE_CARET = 0x4001,

            CONSOLE_UPDATE_REGION = 0x4002,

            CONSOLE_UPDATE_SIMPLE = 0x4003,

            CONSOLE_UPDATE_SCROLL = 0x4004,

            CONSOLE_LAYOUT = 0x4005,

            CONSOLE_START_APPLICATION = 0x4006,

            CONSOLE_END_APPLICATION = 0x4007,

            CONSOLE_END = 0x40FF,

            OBJECT_CREATE = 0x8000, // hwnd ID idChild is created item

            OBJECT_DESTROY = 0x8001, // hwnd ID idChild is destroyed item

            OBJECT_SHOW = 0x8002, // hwnd ID idChild is shown item

            OBJECT_HIDE = 0x8003, // hwnd ID idChild is hidden item

            OBJECT_REORDER = 0x8004, // hwnd ID idChild is parent of zordering children

            OBJECT_FOCUS = 0x8005, // hwnd ID idChild is focused item

            OBJECT_SELECTION = 0x8006, // hwnd ID idChild is selected item (if only one), or idChild is OBJID_WINDOW if complex

            OBJECT_SELECTIONADD = 0x8007, // hwnd ID idChild is item added

            OBJECT_SELECTIONREMOVE = 0x8008, // hwnd ID idChild is item removed

            OBJECT_SELECTIONWITHIN = 0x8009, // hwnd ID idChild is parent of changed selected items

            OBJECT_STATECHANGE = 0x800A, // hwnd ID idChild is item w/ state change

            OBJECT_LOCATIONCHANGE = 0x800B, // hwnd ID idChild is moved/sized item

            OBJECT_NAMECHANGE = 0x800C, // hwnd ID idChild is item w/ name change

            OBJECT_DESCRIPTIONCHANGE = 0x800D, // hwnd ID idChild is item w/ desc change

            OBJECT_VALUECHANGE = 0x800E, // hwnd ID idChild is item w/ value change

            OBJECT_PARENTCHANGE = 0x800F, // hwnd ID idChild is item w/ new parent

            OBJECT_HELPCHANGE = 0x8010, // hwnd ID idChild is item w/ help change

            OBJECT_DEFACTIONCHANGE = 0x8011, // hwnd ID idChild is item w/ def action change

            OBJECT_ACCELERATORCHANGE = 0x8012, // hwnd ID idChild is item w/ keybd accel change

            OBJECT_INVOKED = 0x8013, // hwnd ID idChild is item invoked

            OBJECT_TEXTSELECTIONCHANGED = 0x8014, // hwnd ID idChild is item w? test selection change

            OBJECT_CONTENTSCROLLED = 0x8015,

            SYSTEM_ARRANGMENTPREVIEW = 0x8016,

            OBJECT_END = 0x80FF,

            AIA_START = 0xA000,

            AIA_END = 0xAFFF;
    }
}
