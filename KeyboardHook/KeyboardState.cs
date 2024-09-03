namespace KeyboardHook;

public struct KeyboardState
{
	public bool LCtrlPressed { get; set; }

	public bool RCtrlPressed { get; set; }

	public bool IsCtrlPressed => LCtrlPressed || RCtrlPressed;

	public bool LShiftPressed { get; set; }

	public bool RShiftPressed { get; set; }

	public bool IsShiftPressed => LShiftPressed || RShiftPressed;

	public bool LAltPressed { get; set; }

	public bool RAltPressed { get; set; }

	public bool IsAltPressed => LAltPressed || RAltPressed;
	public bool IsCapsLock { get; set; }

	public KeyboardState(bool lCtrlPressed, bool rCtrlPressed, bool lShiftPressed, bool rShiftPressed, bool lAltPressed, bool rAltPressed, bool isCapsLock)
	{
		LShiftPressed = lShiftPressed;
		RShiftPressed = rShiftPressed;
		LAltPressed = lAltPressed;
		RAltPressed = rAltPressed;
		LCtrlPressed = lCtrlPressed;
		RCtrlPressed = rCtrlPressed;
		IsCapsLock = isCapsLock;
	}

	public KeyboardState(bool ctrlPressed, bool shiftPressed, bool altPressed, bool isCapsLock)
	{
		LShiftPressed = shiftPressed;
		LAltPressed = altPressed;
		LCtrlPressed = ctrlPressed;
		IsCapsLock = isCapsLock;
	}

	public List<VKeys> GetPressedKeys()
	{
		var keys = new List<VKeys>();
		if (LShiftPressed) keys.Add(VKeys.LSHIFT);
		if (RShiftPressed) keys.Add(VKeys.RSHIFT);
		if (LAltPressed) keys.Add(VKeys.LALT);
		if (RAltPressed) keys.Add(VKeys.RALT);
		if (LCtrlPressed) keys.Add(VKeys.LCONTROL);
		if (RCtrlPressed) keys.Add(VKeys.RCONTROL);
		return keys;
	}

	public override string ToString()
	{
		string result = "";
		if (IsCtrlPressed) result += "C";
		if (IsAltPressed) result += "A";
		if (IsShiftPressed) result += "S";
		if (result.Length > 0) result += "-";
		return result;
	}
}