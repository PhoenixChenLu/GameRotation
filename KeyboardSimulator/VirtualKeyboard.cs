using System.Runtime.InteropServices;
using KeyboardSimulator.Entities;

namespace KeyboardSimulator;

public class VirtualKeyboard
{
	private static bool SendInput(INPUT[] inputs)
	{
		var successInputs = ExternMethods.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

		return successInputs == inputs.Length;
	}

	/// <summary>
	/// 按一下指定按键
	/// </summary>
	/// <param name="key">指定的按键</param>
	/// <param name="alt">是否按下Alt键</param>
	/// <param name="ctrl">是否按下Ctrl键</param>
	/// <param name="shift">是否按下Shift键</param>
	/// <returns>是否按键成功</returns>
	public static bool Press(VKeys key, bool alt = false, bool ctrl = false, bool shift = false)
	{
		List<INPUT> inputs = new();

		List<VKeys> altPressed = AltPressed(), ctrlPressed = CtrlPressed(), shiftPressed = ShiftPressed();

		bool altDown = altPressed.Count > 0, ctrlDown = ctrlPressed.Count > 0, shiftDown = shiftPressed.Count > 0;

		if (altDown != alt)
		{
			switch (alt)
			{
				case true:
					inputs.Add(VKeys.LALT.Down());
					break;
				case false:
					inputs.AddRange(altPressed.Select(altKey => altKey.Up()));
					break;
			}
		}

		if (ctrlDown != ctrl)
		{
			switch (ctrl)
			{
				case true:
					inputs.Add(VKeys.LCONTROL.Down());
					break;
				case false:
					inputs.AddRange(ctrlPressed.Select(ctrlKey => ctrlKey.Up()));
					break;
			}
		}

		if (shiftDown != shift)
		{
			switch (shift)
			{
				case true:
					inputs.Add(VKeys.LSHIFT.Down());
					break;
				case false:
					inputs.AddRange(shiftPressed.Select(shiftKey => shiftKey.Up()));
					break;
			}
		}

		inputs.AddRange(key.Press());

		if (altDown != alt)
		{
			switch (alt)
			{
				case true:
					inputs.Add(VKeys.LALT.Up());
					break;
				case false:
					inputs.AddRange(altPressed.Select(altKey => altKey.Down()));
					break;
			}
		}

		if (ctrlDown != ctrl)
		{
			switch (ctrl)
			{
				case true:
					inputs.Add(VKeys.LCONTROL.Up());
					break;
				case false:
					inputs.AddRange(ctrlPressed.Select(ctrlKey => ctrlKey.Down()));
					break;
			}
		}

		if (shiftDown != shift)
		{
			switch (shift)
			{
				case true:
					inputs.Add(VKeys.LSHIFT.Up());
					break;
				case false:
					inputs.AddRange(shiftPressed.Select(shiftKey => shiftKey.Down()));
					break;
			}
		}
		
		return SendInput(inputs.ToArray());
	}

	/// <summary>
	/// 返回按下的Alt键列表
	/// </summary>
	/// <returns>已经按下的Alt键列表</returns>
	private static List<VKeys> AltPressed()
	{
		// 创建一个用于存储按下的Alt键的列表
		List<VKeys> keys = new();

		// 检查左Alt键是否按下
		if (ExternMethods.GetKeyState((int)VKeys.LALT) == -127)
		{
			keys.Add(VKeys.LALT);
		}

		// 检查右Alt键是否按下
		if (ExternMethods.GetKeyState((int)VKeys.RALT) == -127)
		{
			keys.Add(VKeys.RALT);
		}

		// 返回按下的Alt键列表
		return keys;
	}

	/// <summary>
	/// 返回按下的Ctrl键列表
	/// </summary>
	/// <returns>已经按下的Ctrl键列表</returns>
	private static List<VKeys> CtrlPressed()
	{
		List<VKeys> keys = new();
		if (ExternMethods.GetKeyState((int)VKeys.LCONTROL) == -127)
		{
			keys.Add(VKeys.LCONTROL);
		}

		if (ExternMethods.GetKeyState((int)VKeys.RCONTROL) == -127)
		{
			keys.Add(VKeys.RCONTROL);
		}

		return keys;
	}


	/// <summary>
	/// 返回按下的Shift键列表
	/// </summary>
	/// <returns>已经按下的Shift键列表</returns>
	private static List<VKeys> ShiftPressed()
	{
		// 创建一个用于存储按下的Shift键的列表
		List<VKeys> keys = new();

		// 检查左Shift键是否按下
		if (ExternMethods.GetKeyState((int)VKeys.LSHIFT) == -127)
		{
			keys.Add(VKeys.LSHIFT);
		}

		// 检查右Shift键是否按下
		if (ExternMethods.GetKeyState((int)VKeys.RSHIFT) == -127)
		{
			keys.Add(VKeys.RSHIFT);
		}

		// 返回按下的Shift键列表
		return keys;
	}
}