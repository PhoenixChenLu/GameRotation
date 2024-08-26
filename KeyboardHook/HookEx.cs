using System.Runtime.InteropServices;

namespace KeyboardHook;

/// <summary>
/// 用于处理键盘钩子的委托
/// </summary>
public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, ref KeyStrokeInfo keyStrokeInfo);

public static class HookEx
{
	/// <summary>
	/// 设置键盘钩子
	/// </summary>
	/// <param name="idHook">钩子类型</param>
	/// <param name="lpfn">钩子处理函数</param>
	/// <param name="hMod">模块句柄</param>
	/// <param name="dwThreadId">线程ID</param>
	/// <returns>如果成功返回钩子句柄，否则返回IntPtr.Zero</returns>
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr SetWindowsHookEx(int idHook,
		LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

	/// <summary>
	/// 卸载钩子
	/// </summary>
	/// <param name="hhk">钩子句柄</param>
	/// <returns>如果成功返回true，否则返回false</returns>
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnhookWindowsHookEx(IntPtr hhk);

	/// <summary>
	/// 调用下一个钩子
	/// </summary>
	/// <param name="hhk">钩子句柄</param>
	/// <param name="nCode">钩子代码，正常应当>=0，后续通过代码判断如何处理该按键操作</param>
	/// <param name="wParam">消息类型</param>
	/// <param name="lParam">消息参数</param>
	/// <returns>LResult结构体指针，包含nCode、wParam和lParam信息
	/// 其中wParam指示按键按下和弹起的信息
	/// lParam是一个包含按键信息的
	///tagKBDLLHOOKSTRUCT结构体</returns>
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
		IntPtr wParam, ref KeyStrokeInfo lParam);

	/// <summary>
	/// 获得模块句柄
	/// </summary>
	/// <param name="lpModuleName">模块名称</param>
	/// <returns>如果成功返回模块句柄，否则返回IntPtr.Zero</returns>
	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr GetModuleHandle(string lpModuleName);

	/// <summary>
	/// 获取按键状态
	/// </summary>
	/// <param name="keyCode">按键码</param>
	/// <returns>高位为1表示按键按下，否则为0；低位为1则表示按键激活（如CapsLock打开）</returns>
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
	public static extern short GetKeyState(int keyCode);
	
	/// <summary>
	/// 获取窗口句柄
	/// </summary>
	/// <param name="lpClassName">获取的窗口类名称，可以为空</param>
	/// <param name="lpWindowName">要获取的窗口名称，如果为空则所有窗口都会被适配</param>
	/// <returns>如果成功返回窗口句柄，否则返回IntPtr.Zero</returns>
	[DllImport("user32.dll")]
	public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	/// <summary>
	/// 向指定窗口发熊消息
	/// </summary>
	/// <param name="hWnd">指定窗口的句柄，如果为0Xffff则发送给所有窗口，如果为Null则发送到当前进程</param>
	/// <param name="Msg">发送的信息类型，详见https://learn.microsoft.com/en-us/windows/win32/winmsg/about-messages-and-message-queues</param>
	/// <param name="wParam">与信息类型相关的参数</param>
	/// <param name="lParam">与信息类型相关的参数</param>
	/// <returns></returns>
	[DllImport("user32.dll")]
	public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
	
	/// <summary>
	/// 将指定窗口设置为前台窗口
	/// </summary>
	/// <param name="hWnd">指定窗口的句柄</param>
	/// <returns>如果成功返回true，否则返回false</returns>
	[DllImport("USER32.DLL")]
	public static extern bool SetForegroundWindow(IntPtr hWnd);
}