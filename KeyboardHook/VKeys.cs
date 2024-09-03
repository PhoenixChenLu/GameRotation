using System.Reflection;
using System.Runtime.Serialization;

namespace KeyboardHook;

/// <summary>
/// VKey Enums
/// <see cref="http://www.pinvoke.net/default.aspx/Enums/VK.html"/>
/// </summary>
public enum VKeys
{
	///<summary>
	///Left mouse button
	///</summary>
	[EnumMember(Value = "MLB")] LBUTTON = 0x01,

	///<summary>
	///Right mouse button
	///</summary>
	[EnumMember(Value = "MRB")] RBUTTON = 0x02,

	///<summary>
	///Control-break processing
	///</summary>
	[EnumMember(Value = "ESC")] CANCEL = 0x03,

	///<summary>
	///Middle mouse button (three-button mouse)
	///</summary>
	[EnumMember(Value = "MMB")] MBUTTON = 0x04,

	///<summary>
	///Windows 2000/XP: X1 mouse button
	///</summary>
	[EnumMember(Value = "X1MB")] XBUTTON1 = 0x05,

	///<summary>
	///Windows 2000/XP: X2 mouse button
	///</summary>
	[EnumMember(Value = "X2MB")] XBUTTON2 = 0x06,

	///<summary>
	///BACKSPACE key
	///</summary>
	[EnumMember(Value = "BACK")] BACK = 0x08,

	///<summary>
	///TAB key
	///</summary>
	[EnumMember(Value = "TAB")] TAB = 0x09,

	///<summary>
	///CLEAR key
	///</summary>
	[EnumMember(Value = "CLEAR")] CLEAR = 0x0C,

	///<summary>
	///ENTER key
	///</summary>
	[EnumMember(Value = "ENTER")] RETURN = 0x0D,

	///<summary>
	///SHIFT key
	///</summary>
	[EnumMember(Value = "SHIFT")] SHIFT = 0x10,

	///<summary>
	///CTRL key
	///</summary>
	[EnumMember(Value = "CTRL")] CONTROL = 0x11,

	///<summary>
	///ALT key
	///</summary>
	[EnumMember(Value = "ALT")] ALT = 0x12,

	///<summary>
	///PAUSE key
	///</summary>
	[EnumMember(Value = "PAUSE")] PAUSE = 0x13,

	///<summary>
	///CAPS LOCK key
	///</summary>
	[EnumMember(Value = "CAPS")] CAPITAL = 0x14,

	///<summary>
	///Input Method Editor (IME) Kana mode
	///</summary>
	[EnumMember(Value = "KANA")] KANA = 0x15,

	///<summary>
	///IME Hangul mode
	///</summary>
	[EnumMember(Value = "HANGUL")] HANGUL = 0x15,

	///<summary>
	///IME Junja mode
	///</summary>
	[EnumMember(Value = "JUNJA")] JUNJA = 0x17,

	///<summary>
	///IME final mode
	///</summary>
	[EnumMember(Value = "FINAL")] FINAL = 0x18,

	///<summary>
	///IME Hanja mode
	///</summary>
	[EnumMember(Value = "HANJA")] HANJA = 0x19,

	///<summary>
	///IME Kanji mode
	///</summary>
	[EnumMember(Value = "KANJI")] KANJI = 0x19,

	///<summary>
	///ESC key
	///</summary>
	[EnumMember(Value = "ESC")] ESCAPE = 0x1B,

	///<summary>
	///IME convert
	///</summary>
	[EnumMember(Value = "CONVERT")] CONVERT = 0x1C,

	///<summary>
	///IME nonconvert
	///</summary>
	[EnumMember(Value = "NONCONVERT")] NONCONVERT = 0x1D,

	///<summary>
	///IME accept
	///</summary>
	[EnumMember(Value = "ACCEPT")] ACCEPT = 0x1E,

	///<summary>
	///IME mode change request
	///</summary>
	[EnumMember(Value = "MODECHANGE")] MODECHANGE = 0x1F,

	///<summary>
	///SPACEBAR
	///</summary>
	[EnumMember(Value = "SPACE")] SPACE = 0x20,

	///<summary>
	///PAGE UP key
	///</summary>
	[EnumMember(Value = "PGUP")] PRIOR = 0x21,

	///<summary>
	///PAGE DOWN key
	///</summary>
	[EnumMember(Value = "PGDN")] NEXT = 0x22,

	///<summary>
	///END key
	///</summary>
	[EnumMember(Value = "END")] END = 0x23,

	///<summary>
	///HOME key
	///</summary>
	[EnumMember(Value = "HOME")] HOME = 0x24,

	///<summary>
	///LEFT ARROW key
	///</summary>
	[EnumMember(Value = "LEFT")] LEFT = 0x25,

	///<summary>
	///UP ARROW key
	///</summary>
	[EnumMember(Value = "UP")] UP = 0x26,

	///<summary>
	///RIGHT ARROW key
	///</summary>
	[EnumMember(Value = "RIGHT")] RIGHT = 0x27,

	///<summary>
	///DOWN ARROW key
	///</summary>
	[EnumMember(Value = "DOWN")] DOWN = 0x28,

	///<summary>
	///SELECT key
	///</summary>
	[EnumMember(Value = "SELECT")] SELECT = 0x29,

	///<summary>
	///PRINT key
	///</summary>
	[EnumMember(Value = "PRINT")] PRINT = 0x2A,

	///<summary>
	///EXECUTE key
	///</summary>
	[EnumMember(Value = "EXECUTE")] EXECUTE = 0x2B,

	///<summary>
	///PRINT SCREEN key
	///</summary>
	[EnumMember(Value = "PRTSCR")] SNAPSHOT = 0x2C,

	///<summary>
	///INS key
	///</summary>
	[EnumMember(Value = "INS")] INSERT = 0x2D,

	///<summary>
	///DEL key
	///</summary>
	[EnumMember(Value = "DEL")] DELETE = 0x2E,

	///<summary>
	///HELP key
	///</summary>
	[EnumMember(Value = "HELP")] HELP = 0x2F,

	///<summary>
	///0 key
	///</summary>
	[EnumMember(Value = "0")] KEY_0 = 0x30,

	///<summary>
	///1 key
	///</summary>
	[EnumMember(Value = "1")] KEY_1 = 0x31,

	///<summary>
	///2 key
	///</summary>
	[EnumMember(Value = "2")] KEY_2 = 0x32,

	///<summary>
	///3 key
	///</summary>
	[EnumMember(Value = "3")] KEY_3 = 0x33,

	///<summary>
	///4 key
	///</summary>
	[EnumMember(Value = "4")] KEY_4 = 0x34,

	///<summary>
	///5 key
	///</summary>
	[EnumMember(Value = "5")] KEY_5 = 0x35,

	///<summary>
	///6 key
	///</summary>
	[EnumMember(Value = "6")] KEY_6 = 0x36,

	///<summary>
	///7 key
	///</summary>
	[EnumMember(Value = "7")] KEY_7 = 0x37,

	///<summary>
	///8 key
	///</summary>
	[EnumMember(Value = "8")] KEY_8 = 0x38,

	///<summary>
	///9 key
	///</summary>
	[EnumMember(Value = "9")] KEY_9 = 0x39,

	///<summary>
	///A key
	///</summary>
	[EnumMember(Value = "A")] KEY_A = 0x41,

	///<summary>
	///B key
	///</summary>
	[EnumMember(Value = "B")] KEY_B = 0x42,

	///<summary>
	///C key
	///</summary>
	[EnumMember(Value = "C")] KEY_C = 0x43,

	///<summary>
	///D key
	///</summary>
	[EnumMember(Value = "D")] KEY_D = 0x44,

	///<summary>
	///E key
	///</summary>
	[EnumMember(Value = "E")] KEY_E = 0x45,

	///<summary>
	///F key
	///</summary>
	[EnumMember(Value = "F")] KEY_F = 0x46,

	///<summary>
	///G key
	///</summary>
	[EnumMember(Value = "G")] KEY_G = 0x47,

	///<summary>
	///H key
	///</summary>
	[EnumMember(Value = "H")] KEY_H = 0x48,

	///<summary>
	///I key
	///</summary>
	[EnumMember(Value = "I")] KEY_I = 0x49,

	///<summary>
	///J key
	///</summary>
	[EnumMember(Value = "J")] KEY_J = 0x4A,

	///<summary>
	///K key
	///</summary>
	[EnumMember(Value = "K")] KEY_K = 0x4B,

	///<summary>
	///L key
	///</summary>
	[EnumMember(Value = "L")] KEY_L = 0x4C,

	///<summary>
	///M key
	///</summary>
	[EnumMember(Value = "M")] KEY_M = 0x4D,

	///<summary>
	///N key
	///</summary>
	[EnumMember(Value = "N")] KEY_N = 0x4E,

	///<summary>
	///O key
	///</summary>
	[EnumMember(Value = "O")] KEY_O = 0x4F,

	///<summary>
	///P key
	///</summary>
	[EnumMember(Value = "P")] KEY_P = 0x50,

	///<summary>
	///Q key
	///</summary>
	[EnumMember(Value = "Q")] KEY_Q = 0x51,

	///<summary>
	///R key
	///</summary>
	[EnumMember(Value = "R")] KEY_R = 0x52,

	///<summary>
	///S key
	///</summary>
	[EnumMember(Value = "S")] KEY_S = 0x53,

	///<summary>
	///T key
	///</summary>
	[EnumMember(Value = "T")] KEY_T = 0x54,

	///<summary>
	///U key
	///</summary>
	[EnumMember(Value = "U")] KEY_U = 0x55,

	///<summary>
	///V key
	///</summary>
	[EnumMember(Value = "V")] KEY_V = 0x56,

	///<summary>
	///W key
	///</summary>
	[EnumMember(Value = "W")] KEY_W = 0x57,

	///<summary>
	///X key
	///</summary>
	[EnumMember(Value = "X")] KEY_X = 0x58,

	///<summary>
	///Y key
	///</summary>
	[EnumMember(Value = "Y")] KEY_Y = 0x59,

	///<summary>
	///Z key
	///</summary>
	[EnumMember(Value = "Z")] KEY_Z = 0x5A,

	///<summary>
	///Left Windows key (Microsoft Natural keyboard)
	///</summary>
	[EnumMember(Value = "LWIN")] LWIN = 0x5B,

	///<summary>
	///Right Windows key (Natural keyboard)
	///</summary>
	[EnumMember(Value = "RWIN")] RWIN = 0x5C,

	///<summary>
	///Applications key (Natural keyboard)
	///</summary>
	[EnumMember(Value = "APPS")] APPS = 0x5D,

	///<summary>
	///Computer Sleep key
	///</summary>
	[EnumMember(Value = "SLEEP")] SLEEP = 0x5F,

	///<summary>
	///Numeric keypad 0 key
	///</summary>
	[EnumMember(Value = "NUM0")] NUMPAD0 = 0x60,

	///<summary>
	///Numeric keypad 1 key
	///</summary>
	[EnumMember(Value = "NUM1")] NUMPAD1 = 0x61,

	///<summary>
	///Numeric keypad 2 key
	///</summary>
	[EnumMember(Value = "NUM2")] NUMPAD2 = 0x62,

	///<summary>
	///Numeric keypad 3 key
	///</summary>
	[EnumMember(Value = "NUM3")] NUMPAD3 = 0x63,

	///<summary>
	///Numeric keypad 4 key
	///</summary>
	[EnumMember(Value = "NUM4")] NUMPAD4 = 0x64,

	///<summary>
	///Numeric keypad 5 key
	///</summary>
	[EnumMember(Value = "NUM5")] NUMPAD5 = 0x65,

	///<summary>
	///Numeric keypad 6 key
	///</summary>
	[EnumMember(Value = "NUM6")] NUMPAD6 = 0x66,

	///<summary>
	///Numeric keypad 7 key
	///</summary>
	[EnumMember(Value = "NUM7")] NUMPAD7 = 0x67,

	///<summary>
	///Numeric keypad 8 key
	///</summary>
	[EnumMember(Value = "NUM8")] NUMPAD8 = 0x68,

	///<summary>
	///Numeric keypad 9 key
	///</summary>
	[EnumMember(Value = "NUM9")] NUMPAD9 = 0x69,

	///<summary>
	///Multiply key
	///</summary>
	[EnumMember(Value = "MUL")] MULTIPLY = 0x6A,

	///<summary>
	///Add key
	///</summary>
	[EnumMember(Value = "ADD")] ADD = 0x6B,

	///<summary>
	///Separator key
	///</summary>
	[EnumMember(Value = "SEP")] SEPARATOR = 0x6C,

	///<summary>
	///Subtract key
	///</summary>
	[EnumMember(Value = "SUB")] SUBTRACT = 0x6D,

	///<summary>
	///Decimal key
	///</summary>
	[EnumMember(Value = "DEC")] DECIMAL = 0x6E,

	///<summary>
	///Divide key
	///</summary>
	[EnumMember(Value = "DIV")] DIVIDE = 0x6F,

	///<summary>
	///F1 key
	///</summary>
	[EnumMember(Value = "F1")] F1 = 0x70,

	///<summary>
	///F2 key
	///</summary>
	[EnumMember(Value = "F2")] F2 = 0x71,

	///<summary>
	///F3 key
	///</summary>
	[EnumMember(Value = "F3")] F3 = 0x72,

	///<summary>
	///F4 key
	///</summary>
	[EnumMember(Value = "F4")] F4 = 0x73,

	///<summary>
	///F5 key
	///</summary>
	[EnumMember(Value = "F5")] F5 = 0x74,

	///<summary>
	///F6 key
	///</summary>
	[EnumMember(Value = "F6")] F6 = 0x75,

	///<summary>
	///F7 key
	///</summary>
	[EnumMember(Value = "F7")] F7 = 0x76,

	///<summary>
	///F8 key
	///</summary>
	[EnumMember(Value = "F8")] F8 = 0x77,

	///<summary>
	///F9 key
	///</summary>
	[EnumMember(Value = "F9")] F9 = 0x78,

	///<summary>
	///F10 key
	///</summary>
	[EnumMember(Value = "F10")] F10 = 0x79,

	///<summary>
	///F11 key
	///</summary>
	[EnumMember(Value = "F11")] F11 = 0x7A,

	///<summary>
	///F12 key
	///</summary>
	[EnumMember(Value = "F12")] F12 = 0x7B,

	///<summary>
	///F13 key
	///</summary>
	[EnumMember(Value = "F13")] F13 = 0x7C,

	///<summary>
	///F14 key
	///</summary>
	[EnumMember(Value = "F14")] F14 = 0x7D,

	///<summary>
	///F15 key
	///</summary>
	[EnumMember(Value = "F15")] F15 = 0x7E,

	///<summary>
	///F16 key
	///</summary>
	[EnumMember(Value = "F16")] F16 = 0x7F,

	///<summary>
	///F17 key
	///</summary>
	[EnumMember(Value = "F17")] F17 = 0x80,

	///<summary>
	///F18 key
	///</summary>
	[EnumMember(Value = "F18")] F18 = 0x81,

	///<summary>
	///F19 key
	///</summary>
	[EnumMember(Value = "F19")] F19 = 0x82,

	///<summary>
	///F20 key
	///</summary>
	[EnumMember(Value = "F20")] F20 = 0x83,

	///<summary>
	///F21 key
	///</summary>
	[EnumMember(Value = "F21")] F21 = 0x84,

	///<summary>
	///F22 key, (PPC only) Key used to lock device.
	///</summary>
	[EnumMember(Value = "F22")] F22 = 0x85,

	///<summary>
	///F23 key
	///</summary>
	[EnumMember(Value = "F23")] F23 = 0x86,

	///<summary>
	///F24 key
	///</summary>
	[EnumMember(Value = "F24")] F24 = 0x87,

	///<summary>
	///NUM LOCK key
	///</summary>
	[EnumMember(Value = "NUMLOCK")] NUMLOCK = 0x90,

	///<summary>
	///SCROLL LOCK key
	///</summary>
	[EnumMember(Value = "SCROLL")] SCROLL = 0x91,

	///<summary>
	///Left SHIFT key
	///</summary>
	[EnumMember(Value = "LSHIFT")] LSHIFT = 0xA0,

	///<summary>
	///Right SHIFT key
	///</summary>
	[EnumMember(Value = "RSHIFT")] RSHIFT = 0xA1,

	///<summary>
	///Left CONTROL key
	///</summary>
	[EnumMember(Value = "LCTRL")] LCONTROL = 0xA2,

	///<summary>
	///Right CONTROL key
	///</summary>
	[EnumMember(Value = "RCTRL")] RCONTROL = 0xA3,

	///<summary>
	///Left MENU key
	///</summary>
	[EnumMember(Value = "LALT")] LALT = 0xA4,

	///<summary>
	///Right MENU key
	///</summary>
	[EnumMember(Value = "RALT")] RALT = 0xA5,

	///<summary>
	///Windows 2000/XP: Browser Back key
	///</summary>
	[EnumMember(Value = "BROWSER_BACK")] BROWSER_BACK = 0xA6,

	///<summary>
	///Windows 2000/XP: Browser Forward key
	///</summary>
	[EnumMember(Value = "BROWSER_FORWARD")] BROWSER_FORWARD = 0xA7,

	///<summary>
	///Windows 2000/XP: Browser Refresh key
	///</summary>
	[EnumMember(Value = "BROWSER_REFRESH")] BROWSER_REFRESH = 0xA8,

	///<summary>
	///Windows 2000/XP: Browser Stop key
	///</summary>
	[EnumMember(Value = "BROWSER_STOP")] BROWSER_STOP = 0xA9,

	///<summary>
	///Windows 2000/XP: Browser Search key
	///</summary>
	[EnumMember(Value = "BROWSER_SEARCH")] BROWSER_SEARCH = 0xAA,

	///<summary>
	///Windows 2000/XP: Browser Favorites key
	///</summary>
	[EnumMember(Value = "BROWSER_FAVORITES")] BROWSER_FAVORITES = 0xAB,

	///<summary>
	///Windows 2000/XP: Browser Start and Home key
	///</summary>
	[EnumMember(Value = "BROWSER_HOME")] BROWSER_HOME = 0xAC,

	///<summary>
	///Windows 2000/XP: Volume Mute key
	///</summary>
	[EnumMember(Value = "VOLUME_MUTE")] VOLUME_MUTE = 0xAD,

	///<summary>
	///Windows 2000/XP: Volume Down key
	///</summary>
	[EnumMember(Value = "VOLUME_DOWN")] VOLUME_DOWN = 0xAE,

	///<summary>
	///Windows 2000/XP: Volume Up key
	///</summary>
	[EnumMember(Value = "VOLUME_UP")] VOLUME_UP = 0xAF,

	///<summary>
	///Windows 2000/XP: Next Track key
	///</summary>
	[EnumMember(Value = "MEDIA_NEXT_TRACK")] MEDIA_NEXT_TRACK = 0xB0,

	///<summary>
	///Windows 2000/XP: Previous Track key
	///</summary>
	[EnumMember(Value = "MEDIA_PREV_TRACK")] MEDIA_PREV_TRACK = 0xB1,

	///<summary>
	///Windows 2000/XP: Stop Media key
	///</summary>
	[EnumMember(Value = "MEDIA_STOP")] MEDIA_STOP = 0xB2,

	///<summary>
	///Windows 2000/XP: Play/Pause Media key
	///</summary>
	[EnumMember(Value = "MEDIA_PLAY_PAUSE")] MEDIA_PLAY_PAUSE = 0xB3,

	///<summary>
	///Windows 2000/XP: Start Mail key
	///</summary>
	[EnumMember(Value = "LAUNCH_MAIL")] LAUNCH_MAIL = 0xB4,

	///<summary>
	///Windows 2000/XP: Select Media key
	///</summary>
	[EnumMember(Value = "LAUNCH_MEDIA_SELECT")] LAUNCH_MEDIA_SELECT = 0xB5,

	///<summary>
	///Windows 2000/XP: Start Application 1 key
	///</summary>
	[EnumMember(Value = "LAUNCH_APP1")] LAUNCH_APP1 = 0xB6,

	///<summary>
	///Windows 2000/XP: Start Application 2 key
	///</summary>
	[EnumMember(Value = "LAUNCH_APP2")] LAUNCH_APP2 = 0xB7,

	///<summary>
	///Used for miscellaneous characters; it can vary by keyboard.
	///</summary>
	[EnumMember(Value = "OEM_1")] OEM_1 = 0xBA,

	///<summary>
	///Windows 2000/XP: For any country/region, the '+' key
	///</summary>
	[EnumMember(Value = "OEM_PLUS")] OEM_PLUS = 0xBB,

	///<summary>
	///Windows 2000/XP: For any country/region, the ',' key
	///</summary>
	[EnumMember(Value = "OEM_COMMA")] OEM_COMMA = 0xBC,

	///<summary>
	///Windows 2000/XP: For any country/region, the '-' key
	///</summary>
	[EnumMember(Value = "OEM_MINUS")] OEM_MINUS = 0xBD,

	///<summary>
	///Windows 2000/XP: For any country/region, the '.' key
	///</summary>
	[EnumMember(Value = "OEM_PERIOD")] OEM_PERIOD = 0xBE,

	///<summary>
	///Used for miscellaneous characters; it can vary by keyboard.
	///</summary>
	[EnumMember(Value = "OEM_2")] OEM_2 = 0xBF,

	///<summary>
	///Used for miscellaneous characters; it can vary by keyboard.
	///</summary>
	[EnumMember(Value = "`")] OEM_3 = 0xC0,

	///<summary>
	///Used for miscellaneous characters; it can vary by keyboard.
	///</summary>
	[EnumMember(Value = "OEM_4")] OEM_4 = 0xDB,

	///<summary>
	///Used for miscellaneous characters; it can vary by keyboard.
	///</summary>
	[EnumMember(Value = "OEM_5")] OEM_5 = 0xDC,

	///<summary>
	///Used for miscellaneous characters; it can vary by keyboard.
	///</summary>
	[EnumMember(Value = "OEM_6")] OEM_6 = 0xDD,

	///<summary>
	///Used for miscellaneous characters; it can vary by keyboard.
	///</summary>
	[EnumMember(Value = "OEM_7")] OEM_7 = 0xDE,

	///<summary>
	///Used for miscellaneous characters; it can vary by keyboard.
	///</summary>
	[EnumMember(Value = "OEM_8")] OEM_8 = 0xDF,

	///<summary>
	///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
	///</summary>
	[EnumMember(Value = "OEM_102")] OEM_102 = 0xE2,

	///<summary>
	///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
	///</summary>
	[EnumMember(Value = "PROCESSKEY")] PROCESSKEY = 0xE5,

	///<summary>
	///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
	///</summary>
	[EnumMember(Value = "PACKET")] PACKET = 0xE7,

	///<summary>
	///Attn key
	///</summary>
	[EnumMember(Value = "ATTN")] ATTN = 0xF6,

	///<summary>
	///CrSel key
	///</summary>
	[EnumMember(Value = "CRSEL")] CRSEL = 0xF7,

	///<summary>
	///ExSel key
	///</summary>
	[EnumMember(Value = "EXSEL")] EXSEL = 0xF8,

	///<summary>
	///Erase EOF key
	///</summary>
	[EnumMember(Value = "EREOF")] EREOF = 0xF9,

	///<summary>
	///Play key
	///</summary>
	[EnumMember(Value = "PLAY")] PLAY = 0xFA,

	///<summary>
	///Zoom key
	///</summary>
	[EnumMember(Value = "ZOOM")] ZOOM = 0xFB,

	///<summary>
	///Reserved
	///</summary>
	[EnumMember(Value = "NONAME")] NONAME = 0xFC,

	///<summary>
	///PA1 key
	///</summary>
	[EnumMember(Value = "PA1")] PA1 = 0xFD,

	///<summary>
	///Clear key
	///</summary>
	[EnumMember(Value = "OEM_CLEAR")] OEM_CLEAR = 0xFE
}

public static class VKeysExtensions
{
	private static readonly Type _enumType = typeof(VKeys);

	/// <summary>
	/// Get the string representation of the VKey
	/// </summary>
	/// <param name="vKey">The VKey</param>
	/// <returns>The string representation of the VKey</returns>
	public static string GetString(this VKeys vKey)
	{
		return _enumType.GetTypeInfo().DeclaredMembers.SingleOrDefault(x => x.Name == vKey.ToString())?.GetCustomAttribute<EnumMemberAttribute>(false)?.Value ?? vKey.ToString();
	}
}