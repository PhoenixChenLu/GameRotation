namespace KeyboardSimulator.Entities;

public static class ExtensionMethods
{
	/// <summary>
	/// 检测某个键是否是扩展键
	/// </summary>
	/// <param name="key">按键</param>
	/// <returns>是否为扩展按键</returns>
	private static bool IsExtendedKey(VKeys key)
	{
		return key is VKeys.LWIN or VKeys.RWIN or VKeys.ALT or VKeys.LALT or VKeys.RALT or VKeys.CONTROL or VKeys.LCONTROL or VKeys.RCONTROL or VKeys.INSERT or VKeys.DELETE or VKeys.HOME or VKeys.END or VKeys.PRIOR or VKeys.NEXT or VKeys.RIGHT or VKeys.UP or VKeys.LEFT or VKeys.DOWN or VKeys.NUMLOCK or VKeys.CANCEL or VKeys.SNAPSHOT or VKeys.DIVIDE;
	}

	public static uint AsCode(this VKeys key)
	{
		return (uint)key;
	}

	public static uint AsCode(this MapType mapType)
	{
		return (uint)mapType;
	}

	public static Input Down(this VKeys key)
	{
		return new Input()
		{
			Type = 1,
			Data = new KeyboardInputData
			{
				KeyCode = (ushort)key,
				ScanCode = (ushort)ExternMethods.MapVirtualKey(key.AsCode(), MapType.MAPVK_VK_TO_VSC.AsCode() & 0XFFU),
				Flags = IsExtendedKey(key) ? (uint)KeyboardInputFlag.ExtendedKey : 0u,
				Time = 0,
				ExtraInfo = IntPtr.Zero
			}
		};
	}

	public static Input Up(this VKeys key)
	{
		return new Input()
		{
			Type = 1,
			Data = new KeyboardInputData
			{
				KeyCode = (ushort)key,
				ScanCode = (ushort)ExternMethods.MapVirtualKey(key.AsCode(), MapType.MAPVK_VK_TO_VSC.AsCode() & 0XFFU),
				Flags = IsExtendedKey(key) ? (uint)(KeyboardInputFlag.ExtendedKey | KeyboardInputFlag.KeyUp) : (uint)KeyboardInputFlag.KeyUp,
				Time = 0,
				ExtraInfo = IntPtr.Zero
			}
		};
	}

	public static List<Input> Press(this VKeys key)
	{
		return new List<Input>() { key.Down(), key.Up() };
	}
}