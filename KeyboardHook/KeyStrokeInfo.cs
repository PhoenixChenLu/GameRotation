namespace KeyboardHook;

/// <summary>
/// 储存键盘按键信息的结构体
/// </summary>
public struct KeyStrokeInfo
{
	/// <summary>
	/// 按键码
	/// </summary>
	public int KeyCode;

	/// <summary>
	/// 取决于键盘布局的扫描码
	/// </summary>
	public int ScanCode;

	/// <summary>
	/// 是否是功能按键，如Shift、Ctrl、Alt，如果是则为1，否则为0
	/// </summary>
	public int Flags;

	/// <summary>
	/// 按键按下或弹起的时间
	/// </summary>
	public int Time;

	/// <summary>
	/// 额外信息
	/// </summary>
	public int ExtraInfo;
}