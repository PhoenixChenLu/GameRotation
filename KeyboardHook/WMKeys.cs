namespace KeyboardHook;

public enum WMKeys
{
	/// <summary>
	/// 窗口激活和失去焦点
	/// </summary>
	WM_ACTIVATE = 0x0006,

	/// <summary>
	/// 程序命令
	/// </summary>
	WM_APPCOMMAND = 0x0319,

	/// <summary>
	/// 窗口失去键盘焦点
	/// </summary>
	WM_KILLFOCUS = 0x0008,

	/// <summary>
	/// 窗口获得键盘焦点
	/// </summary>
	WM_SETFOCUS = 0x0007,

	/// <summary>
	/// 键盘按下
	/// </summary>
	WM_KEYDOWN = 0x0100,

	/// <summary>
	/// 键盘弹起
	/// </summary>
	WM_KEYUP = 0x0101,

	/// <summary>
	/// 字符输入
	/// </summary>
	WM_CHAR = 0x0102,

	/// <summary>
	/// 死字符输入
	/// </summary>
	WM_DEADCHAR = 0x0103,

	/// <summary>
	/// 系统按键按下
	/// </summary>
	WM_SYSKEYDOWN = 0x0104,

	/// <summary>
	/// 系统按键弹起
	/// </summary>
	WM_SYSKEYUP = 0x0105,

	/// <summary>
	/// 系统字符输入
	/// </summary>
	WM_SYSDEADCHAR = 0x0107,
	
	/// <summary>
	/// Unicode字符输入
	/// </summary>
	WM_UNICHAR = 0x0109
}