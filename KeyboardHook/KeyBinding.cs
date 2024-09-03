namespace KeyboardHook;

public struct KeyBinding
{
	public VKeys Key { get; set; }
	public KeyboardState KeyboardState { get; set; }

	public KeyBinding(VKeys key, KeyboardState keyboardState)
	{
		Key = key;
		KeyboardState = keyboardState;
	}

	public KeyBinding(int keyCode, KeyboardState keyboardState)
	{
		Key = (VKeys)keyCode;
		KeyboardState = keyboardState;
	}
}