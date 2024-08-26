using System.Runtime.InteropServices;

namespace KeyboardSimulator.Entities;

public static class ExternMethods
{
	/// <summary>
	/// 获取按键状态
	/// </summary>
	/// <param name="keyCode">按键码</param>
	/// <returns>高位为1表示按键按下，否则为0；低位为1则表示按键激活（如CapsLock打开）</returns>
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
	public static extern short GetKeyState(int keyCode);

	/// <summary>
	/// 向系统发出输入信息
	/// </summary>
	/// <param name="numberOfInputs">信息输入数组的长度</param>
	/// <param name="inputs">信息输入数组</param>
	/// <param name="sizeOfInputStructure">单个输入信息的长度</param>
	/// <returns>成功发起的输入的数量</returns>
	[DllImport("user32.dll", SetLastError = true)]
	public static extern uint SendInput(uint numberOfInputs, Input[] inputs, int sizeOfInputStructure);
	
	/// <summary>
	/// 用于获取按键的扫描码
	/// </summary>
	/// <param name="uCode">按键的按键码</param>
	/// <param name="uMapType">进行的转化类型</param>
	/// <returns>根据参数和转化类型确定返回值</returns>
	[DllImport("user32.dll")]
	public static extern uint MapVirtualKey(uint uCode, uint uMapType);
}