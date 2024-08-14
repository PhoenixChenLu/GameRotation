namespace KeyboardHook;

public struct KeyBinging
{
	public VKeys Key { get; set; }
	public KeyboardState KeyboardState { get; set; }

	public KeyBinging(VKeys key, KeyboardState keyboardState)
	{
		Key = key;
		KeyboardState = keyboardState;
	}

	public KeyBinging(int keyCode, KeyboardState keyboardState)
	{
		Key = (VKeys)keyCode;
		KeyboardState = keyboardState;
	}
}