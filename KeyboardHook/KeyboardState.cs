namespace KeyboardHook;

public struct KeyboardState
{
	public bool IsCtrlPressed { get; set; }
	public bool IsShiftPressed { get; set; }
	public bool IsAltPressed { get; set; }
	public bool IsCapsLock { get; set; }
	
	public KeyboardState(bool isCtrlPressed, bool isShiftPressed, bool isAltPressed, bool isCapsLock)
	{
		IsCtrlPressed = isCtrlPressed;
		IsShiftPressed = isShiftPressed;
		IsAltPressed = isAltPressed;
		IsCapsLock = isCapsLock;
	}
}